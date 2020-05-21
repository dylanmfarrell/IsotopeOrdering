using AutoMapper;
using FluentValidation.Results;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class ShipmentManager : IShipmentManager {
        private readonly ILogger<ShipmentManager> _logger;
        private readonly IShipmentService _service;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IEventManager _eventManager;
        private readonly IIsotopeOrderingAuthorizationService _authorizationService;

        public ShipmentManager(
            ILogger<ShipmentManager> logger,
            IShipmentService service,
            IMapper mapper,
            ICustomerService customerService,
            IEventManager eventManager,
            IIsotopeOrderingAuthorizationService authorizationService) {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _customerService = customerService;
            _eventManager = eventManager;
            _authorizationService = authorizationService;
        }
        public async Task<ApplicationResult> Create(ShipmentDetailModel model) {
            ShipmentDetailModelValidator validator = new ShipmentDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Shipment shipment = _mapper.Map<Shipment>(model);
                int id = await _service.Create(shipment);
                await _eventManager.CreateEvent(EntityEventType.Shipping, id, Events.Shipment.Created);
                return ApplicationResult.Success("Shipment created", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<ApplicationResult> Edit(ShipmentDetailModel model) {
            ShipmentDetailModelValidator validator = new ShipmentDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Shipment shipment = _mapper.Map<Shipment>(model);
                if (shipment.Status == ShipmentStatus.Cancelled) {
                    shipment.IsDeleted = true;
                }
                int id = await _service.Update(shipment);
                await _eventManager.CreateEvent(EntityEventType.Shipping, id, Events.Shipment.Edited);
                return ApplicationResult.Success("Shipment edited", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<ShipmentDetailModel?> Get(int id) {
            bool isReviewer = await _authorizationService.AuthorizeAsync(Policies.ReviewerPolicy);
            if (isReviewer) {
                return await _service.Get<ShipmentDetailModel>(id);
            }
            CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
            if (customer == null) {
                return null;
            }
            return await _service.Get<ShipmentDetailModel>(id, customer.Id, customer.ParentCustomerId);
        }

        public async Task<ShipmentCenterModel> GetCenter() {
            ShipmentCenterModel center = new ShipmentCenterModel();
            center.Shipments = await _service.GetList<ShipmentItemModel>();
            return center;
        }

        public async Task<List<ShipmentItemModel>> GetListForCurrentCustomer() {
            CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
            //customer not found, return empty list
            if (customer == null) {
                return new List<ShipmentItemModel>();
            }
            return await _service.GetListForCustomer<ShipmentItemModel>(customer.Id, customer.ParentCustomerId);
        }
    }
}
