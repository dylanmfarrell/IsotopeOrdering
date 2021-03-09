using IsotopeOrdering.App;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {

    [Authorize(Policies.AdminPolicy)]
    public class ItemController : BaseController {
        private readonly IItemManager _itemManager;

        public ItemController(IItemManager itemManager) {
            _itemManager = itemManager;
        }

        [HttpGet]
        public async Task<IActionResult> Manage() {
            return View(await _itemManager.GetList());
        }


        [HttpGet]
        public async Task<IActionResult> Create() { 
            return View(await Task.FromResult(new ItemDetailModel()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _itemManager.Create(model);
                SetApplicationResult(result);
                return RedirectToAction(nameof(Manage));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            ItemDetailModel? model = await _itemManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _itemManager.Edit(model);
                SetApplicationResult(result);
                return RedirectToAction(nameof(Manage));
            }
            return View(model);
        }
    }
}