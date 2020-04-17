using IsotopeOrdering.Domain.Enums;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Items {
    public class ShipmentItemModel {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<int> Orders { get; set; } = new List<int>();
        public ShipmentStatus Status { get; set; }
    }
}
