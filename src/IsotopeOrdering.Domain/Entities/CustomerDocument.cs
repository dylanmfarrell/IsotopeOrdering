using IsotopeOrdering.Domain.Entities.Shared;
using MIR.Core.Domain;
using System;

namespace IsotopeOrdering.Domain.Entities {
    public class CustomerDocument : ModelBase {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public Document Document { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }
    }
}
