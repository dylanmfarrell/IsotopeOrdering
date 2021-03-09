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
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class OrderManager : IOrderManager {
        private readonly ILogger<OrderManager> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderService _service;
        private readonly IItemService _itemService;
        private readonly ICustomerService _customerService;
        private readonly IShipmentService _shipmentService;
        private readonly IEventManager _eventService;
        private readonly IIsotopeOrderingAuthorizationService _authorizationService;

        public OrderManager(ILogger<OrderManager> logger,
            IMapper mapper,
            IOrderService service,
            IItemService itemService,
            ICustomerService customerService,
            IShipmentService shipmentService,
            IEventManager eventService,
            IIsotopeOrderingAuthorizationService authorizationService) {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _itemService = itemService;
            _customerService = customerService;
            _shipmentService = shipmentService;
            _eventService = eventService;
            _authorizationService = authorizationService;
        }

        public async Task<OrderDetailModel> GetOrderForm(CustomerItemModel customer) {
            OrderDetailModel model = new OrderDetailModel();
            model.Customer = customer;
            return await GetOrderForm(model);
        }

        public async Task<OrderDetailModel> GetOrderForm(OrderDetailModel order) {
            CustomerItemModel customer = order.Customer;
            order.Items = await _itemService.GetListForOrder<OrderItemDetailModel>(customer.Id, customer.ParentCustomerId);
            List<OrderAddressDetailModel> addresses = await _customerService.GetAddressListForOrder<OrderAddressDetailModel>(customer.Id, customer.ParentCustomerId);
            order.BillingAddresses = addresses.Where(x => x.Type == AddressType.Billing || x.Type == AddressType.Default).ToList();
            order.ShippingAddresses = addresses.Where(x => x.Type == AddressType.Shipping || x.Type == AddressType.Default).ToList();
            return order;
        }

        public async Task<OrderDetailModel?> GetOrderForm(int orderId) {
            OrderDetailModel? order = await Get(orderId);
            if (order == null || !order.CanEdit) {
                return null;
            }
            return await GetOrderForm(order);
        }

        public async Task<ApplicationResult> Create(OrderDetailModel model) {
            OrderDetailModelValidator validator = new OrderDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Order order = _mapper.Map<Order>(model);
                int id = await _service.Create(order);
                await _eventService.CreateEvent(EntityEventType.Order, id, Events.Order.Created);
                if (order.Status == OrderStatus.Sent) {
                    await _eventService.CreateEvent(EntityEventType.Order, id, Events.Order.Sent);
                }
                return ApplicationResult.Success("Order created", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<List<OrderItemModel>> GetListForCurrentCustomer() {
            CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
            //customer not found, return empty list
            if (customer == null) {
                return new List<OrderItemModel>();
            }
            return await _service.GetListForCustomer<OrderItemModel>(customer.Id, customer.ParentCustomerId);
        }

        public async Task<OrderCenterModel> GetCenter() {
            OrderCenterModel center = new OrderCenterModel();
            center.Orders = await _service.GetList<OrderItemModel>();
            return center;
        }

        public async Task<OrderDetailModel?> Get(int id) {
            bool isReviewer = await _authorizationService.AuthorizeAsync(Policies.ReviewerPolicy);
            if (isReviewer) {
                return await _service.Get<OrderDetailModel>(id);
            }
            CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
            if (customer == null) {
                return null;
            }
            return await _service.Get<OrderDetailModel>(id, customer.Id, customer.ParentCustomerId);
        }

        public async Task<OrderItemModel?> GetItem(int id) {
            return await _service.Get<OrderItemModel>(id);
        }

        public async Task<ApplicationResult> Edit(OrderDetailModel model) {
            OrderDetailModelValidator validator = new OrderDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Order order = _mapper.Map<Order>(model);
                if (model.Status == OrderStatus.Cancelled) {
                    order.IsDeleted = true;
                }
                int id = await _service.Update(order);
                await _eventService.CreateEvent(EntityEventType.Order, id, Events.Order.Edited);
                if (order.Status == OrderStatus.Sent) {
                    await _eventService.CreateEvent(EntityEventType.Order, id, Events.Order.Sent);
                }
                return ApplicationResult.Success("Order edited", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<OrderReviewDetailModel?> GetOrderForReview(int id) {
            OrderDetailModel? order = await _service.GetForStatus<OrderDetailModel>(id, OrderStatus.Sent);
            if (order == null) {
                return null;
            }
            return new OrderReviewDetailModel() {
                Order = order
            };
        }

        public async Task<ApplicationResult> SubmitReview(OrderReviewDetailModel review) {
            await _service.UpdateStatus(review.Order.Id, review.Action);
            string eventDescription = string.Empty;
            if (review.Action == OrderStatus.Approved) {
                eventDescription = Events.Order.Approved;
            }
            else if (review.Action == OrderStatus.Denied) {
                eventDescription = Events.Order.Denied;
            }
            else if (review.Action == OrderStatus.Complete) {
                eventDescription = Events.Order.Complete;
            }
            await _eventService.CreateEvent(EntityEventType.Order, review.Order.Id, eventDescription);
            return new ApplicationResult(eventDescription, true);
        }

        public async Task<OrderProcessDetailModel?> GetOrderForProcessing(int id) {
            OrderDetailModel? order = await _service.GetForStatus<OrderDetailModel>(id, OrderStatus.Approved);
            if (order == null) {
                return null;
            }
            OrderProcessDetailModel model = new OrderProcessDetailModel();
            model.OrderReview.Order = order;
            model.Shipment = _mapper.Map<ShipmentDetailModel>(order);
            return model;
        }

        public async Task<ApplicationResult> SubmitProcessing(OrderReviewDetailModel review) {
            await _service.UpdateStatus(review.Order.Id, review.Action);
            string eventDescription = Events.Order.InProcess;
            if (review.Action == OrderStatus.Cancelled) {
                eventDescription = Events.Order.Cancelled;
            }
            else if (review.Action == OrderStatus.AwaitingCustomerApproval) {
                eventDescription = Events.Order.Amended;
                List<OrderItem> items = _mapper.Map<List<OrderItem>>(review.Order.Cart);
                await _service.AmendOrderItems(items);
            }
            await _eventService.CreateEvent(EntityEventType.Order, review.Order.Id, eventDescription);
            return new ApplicationResult(eventDescription, true);
        }

        public async Task<OrderCompleteDetailModel?> GetOrderForCompletion(int id) {
            OrderDetailModel? order = await _service.GetForStatus<OrderDetailModel>(id, OrderStatus.InProcess);
            if (order == null) {
                return null;
            }
            OrderCompleteDetailModel model = new OrderCompleteDetailModel();
            model.OrderReview.Order = order;
            model.Shipments = await _shipmentService.GetForOrder<ShipmentDetailModel>(order.Id);
            return model;
        }

        public async Task<ApplicationResult> SubmitCompletion(OrderReviewDetailModel review) {
            await _service.UpdateStatus(review.Order.Id, review.Action);
            string eventDescription = review.Action == OrderStatus.Complete ? Events.Order.Complete : Events.Order.InProcess;
            await _eventService.CreateEvent(EntityEventType.Order, review.Order.Id, eventDescription);
            return new ApplicationResult(eventDescription, true);
        }

        public async Task<OrderReviewDetailModel?> GetReviewAmendment(int id) {
            CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
            if (customer == null) {
                return null;
            }
            OrderDetailModel? order = await _service.Get<OrderDetailModel>(id, customer.Id, customer.ParentCustomerId);
            if (order == null || order.Status != OrderStatus.AwaitingCustomerApproval) {
                return null;
            }
            return new OrderReviewDetailModel() {
                Order = order
            };
        }

        public async Task<ApplicationResult> SubmitAmendmentReview(OrderReviewDetailModel review) {
            await _service.UpdateStatus(review.Order.Id, review.Action);
            await _eventService.CreateEvent(EntityEventType.Order, review.Order.Id, Events.Order.ApprovedAmendedOrder);
            return new ApplicationResult(Events.Order.ApprovedAmendedOrder, true);
        }
    }
}
