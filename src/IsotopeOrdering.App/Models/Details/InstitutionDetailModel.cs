using IsotopeOrdering.App.Models.Shared;
using MIR.Core.Domain;

namespace IsotopeOrdering.App.Models.Details {
    public class InstitutionDetailModel : ModelBase {
        public string Name { get; set; } = null!;
        public AddressDetailModel Address { get; set; } = new AddressDetailModel();
        public ContactDetailModel SafetyContact { get; set; } = new ContactDetailModel();
        public ContactDetailModel FinancialContact { get; set; } = new ContactDetailModel();
    }
}
