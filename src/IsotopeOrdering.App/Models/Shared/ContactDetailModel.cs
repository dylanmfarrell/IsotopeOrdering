namespace IsotopeOrdering.App.Models.Shared {
    public class ContactDetailModel {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Fax { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public override string ToString() {
            return $"{FullName} -Phone #:{PhoneNumber} -Email:{Email}";
        }
    }
}
