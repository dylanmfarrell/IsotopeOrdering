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
        public async Task<IActionResult> InitiationForm() {
            CustomerItemModel? customer = await _customerManager.GetCurrentCustomer();
            if (customer == null) {
                return NotFound();
            }
            return View(await _formManager.GetInitiationForm(customer));
        }

        [HttpGet]
        [Route("Form/InitiationForm/{customerFormId}")]
        public async Task<IActionResult> InitiationForm(int customerFormId) {
            FormDetailModel? form = await _formManager.GetInitiationForm(customerFormId);
            if (form == null) {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> InitiationForm(FormDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _formManager.SubmitInitiationForm(model);
                SetApplicationResult(result);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(model);
        }

    }


}