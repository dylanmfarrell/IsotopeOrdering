using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsotopeOrdering.Domain.Entities {
    public class Order : ModelBase {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Created;
        public string? FedExNumber { get; set; }
        [StringLength(1000)]
        public string? Notes { get; set; }
        public Address ShippingInformation { get; set; } = null!;
        public Address BillingInformation { get; set; } = null!;
        public List<OrderEvent> Events { get; set; } = new List<OrderEvent>();
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
