using IsotopeOrdering.App;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    [Authorize(Policies.OrderPolicy)]
    public class ShipmentController : BaseController {
        private readonly IShipmentManager _shipmentManager;

        public ShipmentController(IShipmentManager shipmentManager) {
            _shipmentManager = shipmentManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            return View(await _shipmentManager.GetList());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id) {
            ShipmentDetailModel? model = await _shipmentManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int orderId) {
            ShipmentDetailModel? model = await _shipmentManager.GetShipmentFormForOrder(orderId);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int[] orderItemIds) {
            ShipmentDetailModel? model = await _shipmentManager.GetShipmentFormForItems(orderItemIds);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipmentDetailModel model) {
            if (ModelState.IsValid) {
                model.Status = ShipmentStatus.Created;
                ApplicationResult result = await _shipmentManager.Create(model);
                return ApplicationResult(nameof(Index), result);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            ShipmentDetailModel? model = await _shipmentManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShipmentDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _shipmentManager.Edit(model);
                return ApplicationResult(nameof(Index), result);
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Center() {
            return View(await _shipmentManager.GetCenterList());
        }

    }


}