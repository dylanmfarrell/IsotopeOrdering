using IsotopeOrdering.App;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Authorize(Policies.PrivatePolicy)]
        public async Task<IActionResult> InitiationForm() {
            CustomerItemModel? customer = await _customerManager.GetCurrentCustomer();
            if (customer == null) {
                return NotFound();
            }
            return View(await _formManager.GetInitiationForm(customer));
        }

        [HttpGet]
        [Authorize(Policies.PrivatePolicy)]
        [Route("Form/InitiationForm/{customerFormId}")]
        public async Task<IActionResult> InitiationForm(int customerFormId) {
            FormDetailModel? form = await _formManager.GetInitiationForm(customerFormId);
            if (form == null) {
                return NotFound();
            }
            return View(form);
        }

        [HttpGet]
        [Authorize(Policies.PublicPolicy)]
        [Route("Form/InitiationForm/{supervisorEmailAddress}/{formIdentifier}")]
        public async Task<IActionResult> InitiationForm(string supervisorEmailAddress, Guid formIdentifier) {
            FormDetailModel? form = await _formManager.GetInitiationForm(supervisorEmailAddress, formIdentifier);
            if (form == null) {
                return NotFound();
            }
            form.AllowSignatureFromCustomerAdmin = true;
            return View(form);
        }

        [HttpPost]
        [Authorize(Policies.PublicPolicy)]
        [Route("Form/InitiationForm/{supervisorEmailAddress}/{formIdentifier}")]
        public async Task<IActionResult> InitiationForm(string supervisorEmailAddress, Guid formIdentifier, FormDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _formManager.SubmitInitiationFormSignature(supervisorEmailAddress, formIdentifier, model.InitiationModel!.CustomerAdminSignature);
                SetApplicationResult(result);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policies.PrivatePolicy)]
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