using System.ComponentModel.DataAnnotations;

namespace IsotopeOrdering.Domain.Entities.Shared {
    public class ContactInformation {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        [Phone]
        public string Fax { get; set; } = null!;
    }
}
