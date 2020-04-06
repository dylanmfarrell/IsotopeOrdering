using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class Order : ModelBase {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Created;
        public string? FedExNumber { get; set; }
        public string? Notes { get; set; }
        public Address Shipping { get; set; } = null!;
        public Address Billing { get; set; } = null!;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
