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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class OrderManager : IOrderManager {
        private readonly ILogger<OrderManager> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderService _service;
        private readonly IItemService _itemService;
        private readonly ICustomerService _customerService;
        private readonly IInstitutionService _institutionService;
        private readonly IEventManager _eventService;

        public OrderManager(ILogger<OrderManager> logger,
            IMapper mapper,
            IOrderService service,
            IItemService itemService,
            ICustomerService customerService,
            IInstitutionService institutionService,
            IEventManager eventService) {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _itemService = itemService;
            _customerService = customerService;
            _institutionService = institutionService;
            _eventService = eventService;
        }

        public async Task<OrderDetailModel> GetOrderForm(CustomerItemModel customer) {
            await _eventService.CreateEvent(EntityEventType.Customer, customer.Id, Events.Customer.ObtainedOrderForm);
            OrderDetailModel model = new OrderDetailModel();
            model.Customer = customer;
            model.Institution = await _institutionService.GetInstitutionForCustomer<InstitutionItemModel>(customer.Id);
            model.Items = await _itemService.GetListForOrder<OrderItemDetailModel>(customer.Id, customer.ParentCustomerId);
            List<OrderAddressDetailModel> addresses = await _customerService.GetAddressListForOrder<OrderAddressDetailModel>(customer.Id, customer.ParentCustomerId);
            model.BillingAddresses = addresses.Where(x => x.Type == AddressType.Billing || x.Type == AddressType.Default).ToList();
            model.ShippingAddresses = addresses.Where(x => x.Type == AddressType.Shipping || x.Type == AddressType.Default).ToList();
            return model;
        }

        public async Task<ApplicationResult> Create(OrderDetailModel model) {
            OrderDetailModelValidator validator = new OrderDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Order item = _mapper.Map<Order>(model);
                int id = await _service.Create(item);
                await _eventService.CreateEvent(EntityEventType.Order, id, Events.Order.Created);
                return ApplicationResult.Success("Order created", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<OrderItemModel> GetList() {
            return await Task.FromResult(new OrderItemModel());
        }

        public Task<OrderDetailModel?> Get(int id) {
            throw new NotImplementedException();
        }

        public Task<ApplicationResult> Edit(OrderDetailModel model) {
            throw new NotImplementedException();
        }

        public Task<OrderItemModel> GetCenterList() {
            throw new NotImplementedException();
        }

        public Task<OrderDetailModel?> GetOrderForReview(int id) {
            throw new NotImplementedException();
        }

        public Task<ApplicationResult> SubmitReview(OrderReviewDetailModel review) {
            throw new NotImplementedException();
        }
    }
}
