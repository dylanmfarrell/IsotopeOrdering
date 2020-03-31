using AutoMapper;
using FluentValidation.Results;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class FormManager : IFormManager {
        private readonly ILogger<FormManager> _logger;
        private readonly IMapper _mapper;
        private readonly IFormService _service;
        private readonly IItemService _itemService;
        private readonly IInstitutionService _institutionService;
        private readonly IEventService _eventService;

        public FormManager(ILogger<FormManager> logger,
            IMapper mapper,
            IFormService service,
            IItemService itemService,
            IInstitutionService institutionService,
            IEventService eventService) {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _itemService = itemService;
            _institutionService = institutionService;
            _eventService = eventService;
        }

        public async Task<FormDetailModel> GetInitiationForm(CustomerItemModel customer) {
            await _eventService.CreateEvent(EntityEventType.Customer, customer.Id, Events.ObtainedInitiationForm);
            FormDetailModel formDetailModel = await _service.Get<FormDetailModel>(FormType.Initiation);
            formDetailModel.InitiationModel = new FormInitiationDetailModel();
            formDetailModel.InitiationModel.Items = await _itemService.GetListForInitiation<FormInitiationItemModel>();
            formDetailModel.InitiationModel.Institutions = await _institutionService.GetListForInitiation<InstitutionItemModel>();
            formDetailModel.Customer = customer;
            return formDetailModel;
        }

        public async Task<FormDetailModel> GetCompletedInitiationForm(int customerFormId) {
            FormDetailModel form = await _service.GetCustomerForm<FormDetailModel>(customerFormId);
            return form;
        }

        public async Task<ApplicationResult> SubmitInitiationForm(FormDetailModel form) {
            await _eventService.CreateEvent(EntityEventType.Customer, form.Customer.Id, Events.SubmittedInitiationForm);
            var validator = new FormDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(form);
            if (result.IsValid) {
                if (form.CustomerDetailFormId != 0) {
                    await _eventService.CreateEvent(EntityEventType.Customer, form.Customer.Id, Events.ResubmittedInitiationForm, form.CustomerDetailFormId);
                    form.CustomerFormStatus = CustomerFormStatus.Completed;
                }
                else {
                    await _eventService.CreateEvent(EntityEventType.Customer, form.Customer.Id, Events.SubmittedInitiationForm);
                }
                CustomerForm customerForm = _mapper.Map<CustomerForm>(form);
                int updated = await _service.SubmitCustomerForm(customerForm);
                if (updated > 0) {
                    await _eventService.CreateEvent(EntityEventType.Customer, form.Customer.Id, Events.SubmissionSuccessInitiationForm);
                }
            }
            await _eventService.CreateEvent(EntityEventType.Customer, form.Customer.Id, Events.ValidationFailedInitiationForm);
            return ApplicationResult.Error(result);
        }

        public async Task<ApplicationResult> UpdateFormStatus(int customerId, int customerFormId, CustomerFormStatus status) {
            await _eventService.CreateEvent(EntityEventType.Customer, customerId, Events.FormStatusChanged, customerFormId, status.ToString());
            await _service.UpdateCustomerFormStatus(customerFormId, status);
            return ApplicationResult.Success("Form status updated",status);
        }
    }
}
