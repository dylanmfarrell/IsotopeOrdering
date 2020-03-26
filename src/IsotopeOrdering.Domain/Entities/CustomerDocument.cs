using MIR.Core.Domain;
using System;

namespace IsotopeOrdering.Domain.Entities {
    public class CustomerDocument: ModelBase {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }
        public Guid UploadId { get; set; }
    }
}
