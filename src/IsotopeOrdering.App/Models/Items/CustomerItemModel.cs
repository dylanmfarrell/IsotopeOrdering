using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.App.Models.Items {
    public class CustomerItemModel : ModelBase {
        public ContactDetailModel Contact { get; set; } = new ContactDetailModel();
        public int? ParentCustomerId { get; set; }
        public CustomerStatus Status { get; set; }
        public bool IsChild => ParentCustomerId.HasValue;
    }
}
