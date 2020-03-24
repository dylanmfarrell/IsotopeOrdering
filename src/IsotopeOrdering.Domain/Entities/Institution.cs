using IsotopeOrdering.Domain.Entities.Shared;
using MIR.Core.Domain;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class Institution : ModelBase {
        public string Name { get; set; } = null!;
        public Contact SafetyContact { get; set; } = null!;
        public Contact FinancialContact { get; set; } = null!;
        public List<CustomerInstitution> Customers { get; set; } = new List<CustomerInstitution>();
    }
}
