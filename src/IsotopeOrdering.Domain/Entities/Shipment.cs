using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class Shipment : ModelBase {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public ShipmentStatus Status { get; set; }
        public decimal ShippingCharge { get; set; }
        public Address Shipping { get; set; } = null!;
        public List<ShipmentItem> Items { get; set; } = new List<ShipmentItem>();
    }
}
