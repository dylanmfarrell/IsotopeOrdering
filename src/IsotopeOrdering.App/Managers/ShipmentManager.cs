using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class ShipmentManager : IShipmentManager {
        private readonly IShipmentService _shippingService;
        private readonly IOrderService _orderService;
        private readonly IEventManager _eventManager;

        public ShipmentManager(IShipmentService shippingService,
            IOrderService orderService,
            IEventManager eventManager) {
            _shippingService = shippingService;
            _orderService = orderService;
            _eventManager = eventManager;
        }
        public async Task<ApplicationResult> Create(ShipmentDetailModel model) {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationResult> Edit(ShipmentDetailModel model) {
            throw new System.NotImplementedException();
        }

        public async Task<ShipmentDetailModel?> Get(int id) {
            throw new System.NotImplementedException();
        }

        public async Task<List<ShipmentItemModel>> GetCenterList() {
            throw new System.NotImplementedException();
        }

        public async Task<List<ShipmentItemModel>> GetList() {
            throw new System.NotImplementedException();
        }

        public async Task<ShipmentDetailModel> GetShipmentFormForItems(int[] orderItemIds) {
            throw new System.NotImplementedException();
        }

        public async Task<ShipmentDetailModel?> GetShipmentFormForOrder(int orderId) {
            throw new System.NotImplementedException();
        }
    }
}
