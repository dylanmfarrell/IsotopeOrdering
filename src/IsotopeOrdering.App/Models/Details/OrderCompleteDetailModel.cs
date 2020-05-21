using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderCompleteDetailModel {
        public OrderReviewDetailModel OrderReview { get; set; } = new OrderReviewDetailModel();
        public List<ShipmentDetailModel> Shipments { get; set; } = new List<ShipmentDetailModel>();
    }
}
