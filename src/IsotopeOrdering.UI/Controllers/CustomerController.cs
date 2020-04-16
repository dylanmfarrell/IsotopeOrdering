using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
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
}