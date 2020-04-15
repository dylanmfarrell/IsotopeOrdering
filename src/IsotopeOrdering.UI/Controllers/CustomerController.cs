using IsotopeOrdering.App;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    public abstract class BaseController : Controller {
        protected IActionResult ApplicationResult(string view, ApplicationResult result) {
            ViewBag.ApplicationResult = result;
            return View(view);
        }
    }


    public class CustomerController : BaseController {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager) {
            _customerManager = customerManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            return View(await _customerManager.GetList());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id) {
            CustomerDetailModel? model = await _customerManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            CustomerDetailModel? model = await _customerManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _customerManager.Edit(model);
                return ApplicationResult(nameof(Index), result);
            }
            return View(model);
        }
    }

    [Authorize(Policies.OrderPolicy)]
    public class OrderController : BaseController {
        private readonly IOrderManager _orderManager;
        private readonly ICustomerManager _customerManager;

        public OrderController(IOrderManager orderManager, ICustomerManager customerManager) {
            _orderManager = orderManager;
            _customerManager = customerManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            return View(await _orderManager.GetList());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id) {
            OrderDetailModel? model = await _orderManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create() {
            CustomerItemModel? customer = await _customerManager.GetCurrentCustomer();
            if (customer == null) {
                return NotFound();
            }
            return View(await _orderManager.GetOrderForm(customer));
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
    }

    public class ShipmentController : BaseController {

    }

    public class ItemController : BaseController {

    }


}