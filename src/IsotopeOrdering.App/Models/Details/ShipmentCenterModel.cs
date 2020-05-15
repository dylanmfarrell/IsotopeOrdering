using IsotopeOrdering.App.Models.Items;
using System.Collections.Generic;
using System.Linq;

namespace IsotopeOrdering.App.Models.Details {
    public class ShipmentCenterModel {
        public List<ShipmentItemModel> Shipments { get; set; } = new List<ShipmentItemModel>();

        public List<ShipmentItemModel> ShipmentsReadyToShip => Shipments.Where(x => x.ReadyToShip).ToList();
        public int ShipmentsReadyToShipCount => Shipments.Count(x => x.ReadyToShip);

        public List<ShipmentItemModel> ShipmentsCompleted => Shipments.Where(x => x.Completed).ToList();
        public int ShipmentsCompleteCount => Shipments.Count(x => x.Completed);
    }
}
