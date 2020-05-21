using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class ShipmentDetailModel : ModelBase {
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public AddressDetailModel Shipping { get; set; } = new AddressDetailModel();
        public DocumentDetailModel Document { get; set; } = new DocumentDetailModel();
        public string CourierName { get; set; } = null!;
        public string CourierDetails { get; set; } = null!;
        public decimal ShippingCharge { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public ShipmentStatus Status { get; set; }
        public List<ShipmentItemDetailModel> Items { get; set; } = new List<ShipmentItemDetailModel>();
    }
    public class ShipmentItemDetailModel : ModelBase {
        public bool IsSelected { get; set; }
        public OrderItemDetailModel OrderItem { get; set; } = new OrderItemDetailModel();
        public int OrderItemId { get; set; }
        public ShipmentItemStatus Status { get; set; }
        public decimal ShippedRadioactivity { get; set; }
        public string? DamagedReason { get; set; }
    }
}
