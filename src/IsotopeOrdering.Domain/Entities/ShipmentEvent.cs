using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class ShipmentEvent : ModelBase {
        public int ShipmentId { get; set; }
        public string Event { get; set; } = null!;
    }
}
