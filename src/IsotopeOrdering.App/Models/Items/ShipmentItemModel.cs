using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.App.Models.Items {
    public class ShipmentItemModel : ModelBase {
        public string Name { get; set; } = string.Empty;
        public ShipmentStatus Status { get; set; }
        public bool ReadyToShip => Status == ShipmentStatus.Created;
        public bool Completed => Status == ShipmentStatus.Shipped;
    }
}
