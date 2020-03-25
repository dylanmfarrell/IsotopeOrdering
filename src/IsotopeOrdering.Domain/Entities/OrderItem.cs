using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class OrderItem : ModelBase {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public int ItemPriceId { get; set; }
        public ItemConfiguration ItemConfiguration { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string? SpecialInstructions { get; set; }
    }
}
