using MIR.Core.Domain;
using System;

namespace IsotopeOrdering.Domain.Entities {
    public class OrderItem : ModelBase {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int ItemConfigurationId { get; set; }
        public ItemConfiguration ItemConfiguration { get; set; } = null!;
        public DateTime RequestedDate { get; set; }
        public decimal Quantity { get; set; }
        public string? SpecialInstructions { get; set; }
    }
}
