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
        public async Task<IActionResult> MyShipments() {
            return View(await _shipmentManager.GetListForCurrentCustomer());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id) {
            ShipmentDetailModel? model = await _shipmentManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Create(ShipmentDetailModel model) {
            if (ModelState.IsValid) {
                model.Status = ShipmentStatus.Created;
                ApplicationResult result = await _shipmentManager.Create(model);
                SetApplicationResult(result);
                return RedirectToAction(nameof(Center), "Shipment");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Edit(int id) {
            ShipmentDetailModel? model = await _shipmentManager.Get(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Edit(ShipmentDetailModel model) {
            if (ModelState.IsValid) {
                ApplicationResult result = await _shipmentManager.Edit(model);
                SetApplicationResult(result);
                return RedirectToAction(nameof(Center), "Shipment");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Policies.ReviewerPolicy)]
        public async Task<IActionResult> Center() {
            return View(await _shipmentManager.GetCenter());
        }
    }
}