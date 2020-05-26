using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IsotopeOrdering.App.Models.Details {
    public class ShipmentDetailModel : ModelBase {
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public AddressDetailModel Shipping { get; set; } = new AddressDetailModel();
        public DocumentDetailModel Document { get; set; } = new DocumentDetailModel();
        [DisplayName("Courier Name")]
        public string CourierName { get; set; } = null!;
        [DisplayName("Courier Details")]
        public string CourierDetails { get; set; } = null!;
        [DisplayName("Shipment Charge")]
        public decimal ShippingCharge { get; set; }
        [DisplayName("Shipment Date")]
        public DateTime? ShipmentDate { get; set; }
        [DisplayName("Shipment Status")]
        public ShipmentStatus Status { get; set; }
        public List<ShipmentItemDetailModel> Items { get; set; } = new List<ShipmentItemDetailModel>();
    }
    public class ShipmentItemDetailModel : ModelBase {
        public bool IsSelected { get; set; }
        public OrderItemDetailModel OrderItem { get; set; } = new OrderItemDetailModel();
        public int OrderItemId { get; set; }
        [DisplayName("Shipment Material Status")]
        public ShipmentItemStatus Status { get; set; }
        [DisplayName("Shipped Radioactivity")]
        public decimal ShippedRadioactivity { get; set; }
        public string? DamagedReason { get; set; }
    }
}
