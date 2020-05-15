using IsotopeOrdering.Domain.Enums;

namespace IsotopeOrdering.App.Models.Items {
    public class ShipmentItemModel {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ShipmentStatus Status { get; set; }
        public bool ReadyToShip => Status == ShipmentStatus.Created;
        public bool Completed => Status == ShipmentStatus.Shipped;
    }
}
