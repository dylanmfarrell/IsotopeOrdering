using System.Collections.Generic;
using System.Linq;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderCompleteDetailModel {
        public OrderReviewDetailModel OrderReview { get; set; } = new OrderReviewDetailModel();
        public List<ShipmentDetailModel> Shipments { get; set; } = new List<ShipmentDetailModel>();
        public decimal Total => decimal.Round(OrderReview.Order.Cart.Sum(x => x.Price) + Shipments.Sum(x => x.ShippingCharge),2)
    }
}
