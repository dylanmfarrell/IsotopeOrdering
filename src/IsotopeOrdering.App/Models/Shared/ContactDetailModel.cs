﻿namespace IsotopeOrdering.App.Models.Shared {
    public class ContactDetailModel {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
    }
}
