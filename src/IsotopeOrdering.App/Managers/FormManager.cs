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
            if (!string.IsNullOrEmpty(form.FormData)) {
                form.InitiationModel = JsonSerializer.Deserialize<FormInitiationDetailModel>(form.FormData);
            }
            return form;
        }

        public async Task<FormDetailModel?> GetInitiationForm(string supervisorEmailAddress, Guid formIdentifier) {
            FormDetailModel? form = await _service.GetCustomerForm<FormDetailModel>(formIdentifier);
            if (form != null && !string.IsNullOrEmpty(form.FormData)) {
                form.InitiationModel = JsonSerializer.Deserialize<FormInitiationDetailModel>(form.FormData);
                if (form.InitiationModel.CustomerAdminSignature.Email.Trim().Contains(supervisorEmailAddress.Trim(), StringComparison.OrdinalIgnoreCase)) {
                    return form;
                }
            }
            return null;
        }

        public async Task<ApplicationResult> SubmitInitiationForm(FormDetailModel form) {
            var validator = new FormDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(form);
            if (result.IsValid) {
                if (form.Action == CustomerFormStatus.Approved) {
                    return await ApproveInitiationForm(form.CustomerDetailFormId, form.InitiationModel!.AdminSignature);
                }
                if (form.Action == CustomerFormStatus.Denied) {
                    return await DenyInitiationForm(form.Customer.Id, form.CustomerDetailFormId);
                }
                if (form.Action == CustomerFormStatus.AwaitingCustomerSupervisorApproval) {
                    CustomerForm customerForm = _mapper.Map<CustomerForm>(form);
                    int customerFormId = await _service.SubmitCustomerForm(customerForm);
                    await _eventService.CreateEvent(EntityEventType.Customer, form.Customer.Id, Events.Customer.SubmittedInitiationForm);
                    await UpdateFormStatus(form.Customer.Id, customerFormId, form.Action);
                    await _notificationManager.ProcessExternalMtaNotification(form);
                }
                return ApplicationResult.Success("Form submitted", form.CustomerDetailFormId);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<ApplicationResult> SubmitInitiationFormSignature(string supervisorEmailAddress, Guid formIdentifier, FormInitiationSignatureModel signature) {
            FormDetailModel? form = await GetInitiationForm(supervisorEmailAddress, formIdentifier);
            if (form == null || form.InitiationModel == null) {
                return ApplicationResult.Error("Unable to find form for supervisor email");
            }
            form.InitiationModel.CustomerAdminSignature = signature;
            CustomerForm customerForm = _mapper.Map<CustomerForm>(form);
            await _service.SubmitCustomerForm(customerForm);
            await UpdateFormStatus(form.Customer.Id, form.CustomerDetailFormId, CustomerFormStatus.AwaitingAdminApproval);
            return ApplicationResult.Success("Form signed", form.CustomerDetailFormId);
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

        private async Task<ApplicationResult> ApproveInitiationForm(int formId, FormInitiationSignatureModel signature) {
            FormDetailModel? form = await GetInitiationForm(formId);
            if (form == null) {
                return ApplicationResult.Error("Unable to find form for admin approval email");
            }
            form.InitiationModel!.AdminSignature = signature;
            CustomerForm customerForm = _mapper.Map<CustomerForm>(form);
            await _service.SubmitCustomerForm(customerForm);
            await UpdateFormStatus(form.Customer.Id, form.CustomerDetailFormId, CustomerFormStatus.Approved);
            //await UpdateCustomerFromInitiationForm(form);
            return ApplicationResult.Success("Form signed", form.CustomerDetailFormId);
        }

        public async Task<ApplicationResult> DenyInitiationForm(int customerId, int formId) {
            await UpdateFormStatus(customerId, formId, CustomerFormStatus.Denied);
            return ApplicationResult.Success("Initiation Form Denied", formId);
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
