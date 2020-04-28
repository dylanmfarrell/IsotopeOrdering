using IsotopeOrdering.App;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {

    public class ItemController : BaseController {
        private readonly IItemManager _itemManager;

        public ItemController(IItemManager itemManager) {
            _itemManager = itemManager;
        }

        [HttpGet]
        [Authorize(Policies.AdminPolicy)]
        public async Task<IActionResult> Index() {
            return View(await _itemManager.GetList());
        }

        [HttpGet]
        [Authorize(Policies.AdminPolicy)]
        public async Task<IActionResult> Detail(int id) {
            ItemDetailModel? model = await _itemManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Policies.AdminPolicy)]
        public async Task<IActionResult> Create() {
            return View(await Task.FromResult(new ItemDetailModel()));
        }

        [HttpPost]
        [Authorize(Policies.AdminPolicy)]
        public async Task<IActionResult> Create(ItemDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _itemManager.Create(model);
                return ApplicationResult(nameof(Index), result);
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Policies.AdminPolicy)]
        public async Task<IActionResult> Edit(int id) {
            ItemDetailModel? model = await _itemManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policies.AdminPolicy)]
        public async Task<IActionResult> Edit(ItemDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _itemManager.Edit(model);
                return ApplicationResult(nameof(Index), result);
            }
            return View(model);
        }
    }
}