using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;

namespace IsotopeOrdering.App.Models.Items {
    public class ShipmentItemModel : ModelBase {
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public int NumberOfItems { get; set; }
        public DateTime ShipmentDate { get; set; }
        public ShipmentStatus Status { get; set; }
        public bool ReadyToShip => Status == ShipmentStatus.Created;
        public bool Completed => Status == ShipmentStatus.Shipped;
    }
}
