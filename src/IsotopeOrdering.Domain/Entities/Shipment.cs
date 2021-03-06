﻿using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class Shipment : ModelBase {
        public ShipmentStatus Status { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string? CourierName { get; set; }
        public string? CourierDetails { get; set; }
        public decimal? ShippingCharge { get; set; }
        public Address Shipping { get; set; } = null!;
        public List<ShipmentItem> Items { get; set; } = new List<ShipmentItem>();
        public Document Document { get; set; } = new Document();
    }
}
