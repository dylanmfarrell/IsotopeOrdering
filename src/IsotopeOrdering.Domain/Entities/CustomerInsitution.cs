using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class CustomerInstitution : ModelBase {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; } = null!;
        public CustomerInstitutionRelationship Relationship { get; set; }
    }
}
