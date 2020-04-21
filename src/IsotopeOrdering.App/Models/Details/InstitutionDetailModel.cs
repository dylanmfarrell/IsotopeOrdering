using IsotopeOrdering.App.Models.Shared;

namespace IsotopeOrdering.App.Models.Details {
    public class InstitutionDetailModel {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public AddressDetailModel Address { get; set; } = new AddressDetailModel();
        public ContactDetailModel SafetyContact { get; set; } = new ContactDetailModel();
        public ContactDetailModel FinancialContact { get; set; } = new ContactDetailModel();
    }
}
