using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class ShipmentItem : ModelBase {
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; } = null!;
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; } = null!;
        public ShipmentItemStatus Status { get; set; }
        public decimal ShippedRadioactivity { get; set; }
        public decimal? ReceivedRadioactivity { get; set; }
        public string? DamagedReason { get; set; }
    }
}
