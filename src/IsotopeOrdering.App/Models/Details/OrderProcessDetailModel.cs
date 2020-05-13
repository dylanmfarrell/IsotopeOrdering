namespace IsotopeOrdering.App.Models.Details {
    public class OrderProcessDetailModel {
        public OrderReviewDetailModel OrderReview { get; set; } = new OrderReviewDetailModel();
        public ShipmentDetailModel Shipment { get; set; } = new ShipmentDetailModel();
    }
}
