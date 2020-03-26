using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class Shipment : ModelBase {
        public ShipmentStatus Status { get; set; }
        public string CourierName { get; set; } = null!;
        public string CourierDetails { get; set; } = null!;
        public decimal ShippingCharge { get; set; }
        public Address Shipping { get; set; } = null!;
        public List<ShipmentItem> Items { get; set; } = new List<ShipmentItem>();
        public Guid UploadId { get; set; }
    }
}
