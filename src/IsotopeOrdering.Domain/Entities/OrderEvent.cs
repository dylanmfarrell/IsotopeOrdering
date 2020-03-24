using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class OrderEvent : ModelBase {
        public int OrderId { get; set; }
        public string Event { get; set; } = null!;
    }
}
