using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;

namespace IsotopeOrdering.App.Models.Items {
    public class CustomerItemModel {
        public int Id { get; set; }
        public ContactDetailModel Contact { get; set; } = new ContactDetailModel();
        public int? ParentCustomerId { get; set; }
        public CustomerStatus Status { get; set; }
    }
}
