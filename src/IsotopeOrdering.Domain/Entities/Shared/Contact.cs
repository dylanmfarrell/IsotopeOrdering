namespace IsotopeOrdering.Domain.Entities.Shared {
    public class Contact {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Fax { get; set; }
    }
}
