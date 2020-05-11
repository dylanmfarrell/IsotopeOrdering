using IsotopeOrdering.Domain.Enums;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderReviewDetailModel {
        public OrderStatus Action { get; set; }
        public OrderDetailModel Order { get; set; } = new OrderDetailModel();
    }
}
