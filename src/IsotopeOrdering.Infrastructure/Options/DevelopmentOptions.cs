using IsotopeOrdering.Domain.Enums;

namespace IsotopeOrdering.Infrastructure.Options {
    public class DevelopmentOptions {
        public bool UseDevelopmentSettings { get; set; }
        public UserRole DevelopmentRole { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
        public string EducationId { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
