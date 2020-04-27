using IsotopeOrdering.App;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    public class CustomerController : BaseController {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager) {
            _customerManager = customerManager;
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> ManageCustomers() {
            return View(await _customerManager.GetList());
        }

        [HttpGet]
        public async Task<IActionResult> MyTeam() {
            return View(await _customerManager.GetList());
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile() {
            CustomerItemModel? customer = await _customerManager.GetCurrentCustomer();
            if (customer == null) {
                return NotFound();
            }
            CustomerDetailModel? model = await _customerManager.Get(customer.Id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MyProfile(CustomerDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _customerManager.Edit(model);
                SetApplicationResult(result);
                return RedirectToAction(nameof(MyProfile));
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
                SetApplicationResult(result);
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAddress(CustomerAddressDetailModel model) {
            return await Task.Run(() => {
                if (ModelState.IsValid) {
                    return PartialView("_CustomerAddress", model);
                }
                return JsonValidationErrorResult(ModelState);
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerInstituion(CustomerInstitutionDetailModel model) {
            model.Relationship = CustomerInstitutionRelationship.Primary;
            return await Task.Run(() => {
                if (ModelState.IsValid) {
                    return PartialView("_CustomerInstitution", model);
                }
                return JsonValidationErrorResult(ModelState);
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerDocument(CustomerDocumentDetailModel model) {
            return await Task.Run(() => {
                if (ModelState.IsValid) {
                    return PartialView("_CustomerDocument", model);
                }
                return JsonValidationErrorResult(ModelState);
            });
        }
    }
}