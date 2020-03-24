using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class Shipment : ModelBase {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public ShipmentStatus Status { get; set; }
        public Address ShippingInformation { get; set; } = null!;
    }
}
