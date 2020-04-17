using IsotopeOrdering.Domain.Enums;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderReviewDetailModel {
        public Dictionary<OrderStatus, string> Statuses { get; } = new Dictionary<OrderStatus, string>() {
            {OrderStatus.Denied, OrderStatus.Denied.ToString()},
            {OrderStatus.Approved, OrderStatus.Approved.ToString()}
        };
        public OrderStatus SelectedStatus { get; set; }
        public OrderDetailModel Order { get; set; } = new OrderDetailModel();
    }
}
