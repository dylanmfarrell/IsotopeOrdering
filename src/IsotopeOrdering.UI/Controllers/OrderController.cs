using IsotopeOrdering.App;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    [Authorize(Policies.OrderPolicy)]
    public class OrderController : BaseController {
        private readonly IOrderManager _orderManager;
        private readonly ICustomerManager _customerManager;
        private readonly IItemManager _itemManager;
        private readonly IIsotopeOrderingAuthorizationService _authorizationService;
        private readonly IShipmentManager _shipmentManager;

        public OrderController(IOrderManager orderManager,
            ICustomerManager customerManager,
            IItemManager itemManager,
            IIsotopeOrderingAuthorizationService authorizationService,
            IShipmentManager shipmentManager) {
            _orderManager = orderManager;
            _customerManager = customerManager;
            _itemManager = itemManager;
            _authorizationService = authorizationService;
            _shipmentManager = shipmentManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create() {
            if (await _authorizationService.AuthorizeAsync(Policies.AdminPolicy)) {
                return View(null);
            }
            CustomerItemModel? customer = await _customerManager.GetCurrentCustomer();
            if (customer == null) {
                return NotFound();
            }
            return View(await _orderManager.GetOrderForm(customer));
        }

        [HttpGet]
        [Route("Order/Create/{customerId}")]
        [Authorize(Policies.AdminPolicy)]
        public async Task<IActionResult> Create(int customerId) {
            CustomerItemModel? customer = await _customerManager.GetCustomerItem(customerId);
            if (customer == null) {
                return NotFound();
            }
            return View(await _orderManager.GetOrderForm(customer));
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDetailModel model) {
            if (ModelState.IsValid) {
                model.Status = model.SubmitAction;
                ApplicationResult itemConfigurationResult = await _itemManager.ApplyItemConfigurations(model);
                if (!itemConfigurationResult.IsSuccessful) {
                    SetApplicationResult(itemConfigurationResult);
                    return View(await _orderManager.GetOrderForm(model));
                }
                ApplicationResult result = await _orderManager.Create(model);
                SetApplicationResult(result);
                return RedirectToAction(nameof(Confirmation), "Order", new { orderId = (int)result.Data! });
            }
            return View(await _orderManager.GetOrderForm(model));
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation(int orderId) {
            OrderItemModel? order = await _orderManager.GetItem(orderId);
            if (order == null) {
                return NotFound();
            }
            return View(order);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            OrderDetailModel? model = await _orderManager.GetOrderForm(id);
            if (model == null) {
                return NotFound();
            }
            model.CanEdit = false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderDetailModel model) {
            if (ModelState.IsValid) {
                model.Status = model.SubmitAction;
                ApplicationResult itemConfigurationResult = await _itemManager.ApplyItemConfigurations(model);
                if (!itemConfigurationResult.IsSuccessful) {
                    SetApplicationResult(itemConfigurationResult);
                    return View(await _orderManager.GetOrderForm(model));
                }
                ApplicationResult result = await _orderManager.Edit(model);
                SetApplicationResult(result);
                return RedirectToAction(nameof(Confirmation), "Order", new { orderId = (int)result.Data! });
            }
            OrderDetailModel form = await _orderManager.GetOrderForm(model);
            return View(form);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id) {
            OrderDetailModel? model = await _orderManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders() {
            return View(await _orderManager.GetListForCurrentCustomer());
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Center() {
            return View(await _orderManager.GetCenter());
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Review(int id) {
            OrderReviewDetailModel? model = await _orderManager.GetOrderForReview(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Review(OrderReviewDetailModel model) {
            ApplicationResult result = await _orderManager.SubmitReview(model);
            SetApplicationResult(result);
            return RedirectToAction(nameof(Center), "Order");
        }


        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Process(int id) {
            OrderProcessDetailModel? model = await _orderManager.GetOrderForProcessing(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Process(OrderProcessDetailModel model) {
            ApplicationResult result = await _orderManager.SubmitProcessing(model.OrderReview);
            if (model.OrderReview.Action == OrderStatus.Cancelled || model.OrderReview.Action == OrderStatus.AwaitingCustomerApproval) {
                SetApplicationResult(result);
                return RedirectToAction(nameof(Center), "Order");
            }
            ApplicationResult shipmentResult = await _shipmentManager.Create(model.Shipment);
            SetApplicationResult(shipmentResult);
            if (!shipmentResult.IsSuccessful) {
                return RedirectToAction(nameof(Center), "Order");
            }
            return RedirectToAction(nameof(ShipmentController.Detail), "Shipment", new { id = (int)shipmentResult.Data! });
        }

        [HttpGet]
        public async Task<IActionResult> ReviewAmendment(int id) {
            OrderReviewDetailModel? model = await _orderManager.GetReviewAmendment(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ReviewAmendment(OrderReviewDetailModel model) {
            ApplicationResult result = await _orderManager.SubmitAmendmentReview(model);
            SetApplicationResult(result);
            return RedirectToAction(nameof(MyOrders), "Order");
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Complete(int id) {
            OrderCompleteDetailModel? model = await _orderManager.GetOrderForCompletion(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Complete(OrderCompleteDetailModel model) {
            ApplicationResult result = await _orderManager.SubmitReview(model.OrderReview);
            SetApplicationResult(result);
            return RedirectToAction(nameof(Center), "Order");
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(OrderItemDetailModel model) {
            ItemConfigurationDetailModel? config = await _itemManager.GetItemConfiguration(model.Item.Id, model.CustomerId, null, model.Quantity);
            if (config == null) {
                ModelState.AddModelError("ItemConfigurationNotFound", "Item configuration not found for customer");
                return JsonValidationErrorResult(ModelState);
            }
            model.ItemConfiguration = config;
            model.ItemConfigurationId = config.Id;
            return await Partial("_OrderCartItem", model);
        }
    }
}