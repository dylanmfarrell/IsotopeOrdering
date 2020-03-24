using System.ComponentModel.DataAnnotations;

namespace IsotopeOrdering.Domain.Entities.Shared {
    public class Address {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(2, MinimumLength = 1)]
        public string State { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; } = null!;
        [Required]
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
    }
}
