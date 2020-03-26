using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class CustomerAddress : ModelBase {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public AddressType Type { get; set; }
        public Address Address { get; set; } = null!;
    }
}
