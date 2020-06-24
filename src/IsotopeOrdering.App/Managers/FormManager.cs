using AutoMapper;
using FluentValidation.Results;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class FormManager : IFormManager {
        private readonly ILogger<FormManager> _logger;
        private readonly IMapper _mapper;
        private readonly IFormService _service;
        private readonly IItemService _itemService;
        private readonly IIsotopeOrderingAuthorizationService _authorizationService;
        private readonly ICustomerService _customerService;
        private readonly IEventManager _eventService;
        private readonly INotificationManager _notificationManager;

        public FormManager(ILogger<FormManager> logger,
            IMapper mapper,
            IFormService service,
            IItemService itemService,
            IInstitutionService institutionService,
            IIsotopeOrderingAuthorizationService authorizationService,
            ICustomerService customerService,
            IEventManager eventService,
            INotificationManager notificationManager) {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _itemService = itemService;
            _authorizationService = authorizationService;
            _customerService = customerService;
            _eventService = eventService;
            _notificationManager = notificationManager;
        }

        public async Task<CustomerFormStatus> GetCustomerInitiationFormStatus(int customerId) {
            return await _service.GetInitiationFormStatus(customerId);
        }

        public async Task<FormDetailModel> GetInitiationForm(CustomerItemModel customer) {
            FormDetailModel formDetailModel = await _service.Get<FormDetailModel>(FormType.Initiation);
            formDetailModel.InitiationModel = new FormInitiationDetailModel();
            formDetailModel.InitiationModel.Items = await _itemService.GetListForInitiation<FormInitiationItemModel>();
            formDetailModel.Customer = customer;
            return formDetailModel;
        }

        public async Task<FormDetailModel?> GetInitiationForm(int id) {
            FormDetailModel? form = await GetForm(id);
            if (form == null) {
                return null;
            }
            form.InitiationModel = JsonSerializer.Deserialize<FormInitiationDetailModel>(form.FormData);
            return form;
        }

        public async Task<FormDetailModel?> GetInitiationForm(Guid formIdentifier) {
            FormDetailModel? form = await _service.GetCustomerForm<FormDetailModel>(formIdentifier);
            if (form == null) {
                return null;
            }
            form.InitiationModel = JsonSerializer.Deserialize<FormInitiationDetailModel>(form.FormData);
            return form;
        }

        public async Task<ApplicationResult> SubmitInitiationForm(FormDetailModel form) {
            var validator = new FormDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(form);
            if (result.IsValid) {
                CustomerForm customerForm = _mapper.Map<CustomerForm>(form);
                int formId = await _service.SubmitCustomerForm(customerForm);
                if (form.Id == 0) {
                    await _eventService.CreateEvent(EntityEventType.Customer, form.Customer.Id, Events.Customer.SubmittedInitiationForm);
                }
                if (form.Action == CustomerFormStatus.AwaitingCustomerSupervisorApproval) {
                    await UpdateFormStatus(form.Customer.Id, formId, form.Action);
                    await _notificationManager.ProcessExternalMtaNotification(form);
                }
                return ApplicationResult.Success("Form submitted", formId);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<ApplicationResult> UpdateFormStatus(int customerId, int customerFormId, CustomerFormStatus status) {
            await _eventService.CreateEvent(EntityEventType.Customer, customerId, Events.Customer.FormStatusChanged);
            await _service.UpdateCustomerFormStatus(customerFormId, status);
            return ApplicationResult.Success("Form status updated", status);
        }

        public async Task<List<FormItemModel>> GetList() {
            if (await _authorizationService.AuthorizeAsync(Policies.ReviewerPolicy)) {
                return await _service.GetCustomerForms<FormItemModel>();
            }
            CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
            if (customer == null) {
                return new List<FormItemModel>();
            }
            return await _service.GetCustomerForms<FormItemModel>(customer.Id);
        }

        private async Task<FormDetailModel?> GetForm(int id) {
            bool isReviewer = await _authorizationService.AuthorizeAsync(Policies.ReviewerPolicy);
            if (isReviewer) {
                return await _service.GetCustomerForm<FormDetailModel>(id);
            }
            CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
            if (customer == null) {
                return null;
            }
            return await _service.GetCustomerForm<FormDetailModel>(customer.Id, id);
        }
    }
}
