using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    public class FormController : BaseController {
        private readonly IFormManager _formManager;
        private readonly ICustomerManager _customerManager;

        public FormController(IFormManager formManager, ICustomerManager customerManager) {
            _formManager = formManager;
            _customerManager = customerManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            return View(await _formManager.GetList());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id) {
            FormDetailModel? model = await _formManager.Get(id);
            if(model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> InitiationForm() {
            CustomerItemModel? customer = await _customerManager.GetCurrentCustomer();
            if (customer == null) {
                return NotFound();
            }
            return View(await _formManager.GetInitiationForm(customer));
        }

        [HttpPost]
        public async Task<IActionResult> InitiationForm(FormDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _formManager.SubmitInitiationForm(model);
                return ApplicationResult(nameof(HomeController.Index), result);
            }
            return View(model);
        }

    }


}