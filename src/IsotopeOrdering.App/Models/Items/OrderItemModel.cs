using IsotopeOrdering.Domain.Enums;

namespace IsotopeOrdering.App.Models.Items {
    public class OrderItemModel {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public OrderStatus Status { get; set; }
    }
}
