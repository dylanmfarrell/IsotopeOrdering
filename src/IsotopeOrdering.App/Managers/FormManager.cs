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
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class FormManager : IFormManager {
        private readonly ILogger<FormManager> _logger;
        private readonly IMapper _mapper;
        private readonly IFormService _service;
        private readonly IItemService _itemService;
        private readonly IIsotopeOrderingAuthorizationService _authenticationService;
        private readonly ICustomerService _customerService;
        private readonly IEventManager _eventService;

        public FormManager(ILogger<FormManager> logger,
            IMapper mapper,
            IFormService service,
            IItemService itemService,
            IInstitutionService institutionService,
            IIsotopeOrderingAuthorizationService authenticationService,
            ICustomerService customerService,
            IEventManager eventService) {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _itemService = itemService;
            _authenticationService = authenticationService;
            _customerService = customerService;
            _eventService = eventService;
        }

        public async Task<FormDetailModel> GetInitiationForm(CustomerItemModel customer) {
            FormDetailModel formDetailModel = await _service.Get<FormDetailModel>(FormType.Initiation);
            formDetailModel.InitiationModel = new FormInitiationDetailModel();
            formDetailModel.InitiationModel.Items = await _itemService.GetListForInitiation<FormInitiationItemModel>();
            formDetailModel.Customer = customer;
            return formDetailModel;
        }

        public async Task<FormDetailModel?> Get(int customerFormId) {
            FormDetailModel? form = await _service.GetCustomerForm<FormDetailModel>(customerFormId);
            if (form != null && !string.IsNullOrEmpty(form.FormData)) {
                form.InitiationModel = JsonSerializer.Deserialize<FormInitiationDetailModel>(form.FormData);
            }
            return form;
        }

        public async Task<ApplicationResult> SubmitInitiationForm(FormDetailModel form) {
            var validator = new FormDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(form);
            if (result.IsValid) {
                CustomerForm customerForm = _mapper.Map<CustomerForm>(form);
                int formId = await _service.SubmitCustomerForm(customerForm);
                await _eventService.CreateEvent(EntityEventType.Customer, form.Customer.Id, Events.Customer.SubmittedInitiationForm);
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
            if (await _authenticationService.AuthorizeAsync(Policies.ReviewerPolicy)) {
                return await _service.GetCustomerForms<FormItemModel>();
            }
            CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
            if (customer == null) {
                return new List<FormItemModel>();
            }
            return await _service.GetCustomerForms<FormItemModel>(customer.Id);
        }
    }
}
