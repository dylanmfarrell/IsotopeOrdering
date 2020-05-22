using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class ItemConfiguration : ModelBase {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public decimal? MinimumAmount { get; set; }
        public decimal? MaximumAmount { get; set; }
    }
}
