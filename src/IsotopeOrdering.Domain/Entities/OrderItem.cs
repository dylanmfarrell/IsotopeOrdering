using MIR.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace IsotopeOrdering.Domain.Entities {
    public class OrderItem : ModelBase {
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        [Required]
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        [Required]
        public int AppliedItemPriceId { get; set; }
        public ItemPrice AppliedItemPrice { get; set; } = null!;
        [Required]
        [Range(0.00, 300)]
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string? SpecialInstructions { get; set; }
    }
}
