using IsotopeOrdering.App;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    [Authorize(Policies.OrderPolicy)]
    public class OrderController : BaseController {
        private readonly IOrderManager _orderManager;
        private readonly ICustomerManager _customerManager;
        private readonly IIsotopeOrderingAuthorizationService _authorizationService;

        public OrderController(IOrderManager orderManager,
            ICustomerManager customerManager,
            IIsotopeOrderingAuthorizationService authorizationService) {
            _orderManager = orderManager;
            _customerManager = customerManager;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            return View(await _orderManager.GetList());
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
            CustomerItemModel? customer = await _customerManager.GetItem(customerId);
            if (customer == null) {
                return NotFound();
            }
            return View(await _orderManager.GetOrderForm(customer));
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDetailModel model) {
            if (ModelState.IsValid) {
                model.Status = OrderStatus.Sent;
                ApplicationResult result = await _orderManager.Create(model);
                return ApplicationResult(nameof(Index), result);
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> CreateDraft(OrderDetailModel model) {
            if (ModelState.IsValid) {
                model.Status = OrderStatus.Draft;
                ApplicationResult result = await _orderManager.Create(model);
                return ApplicationResult(nameof(Index), result);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            OrderDetailModel? model = await _orderManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _orderManager.Edit(model);
                return ApplicationResult(nameof(Index), result);
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Center() {
            return View(await _orderManager.GetCenterList());
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Review(int id) {
            OrderDetailModel? model = await _orderManager.GetOrderForReview(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        public async Task<IActionResult> AddCartItem(OrderItemDetailModel model) => await Partial("_OrderCartItem", model);
    }


}