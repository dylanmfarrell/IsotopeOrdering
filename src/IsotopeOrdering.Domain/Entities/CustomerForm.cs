using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;

namespace IsotopeOrdering.Domain.Entities {
    public class CustomerForm : ModelBase {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int FormId { get; set; }
        public Form Form { get; set; } = null!;
        public Guid FormIdentifier { get; set; } = new Guid();
        public CustomerFormStatus Status { get; set; }
        public string? FormData { get; set; }
    }
}
