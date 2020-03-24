using MIR.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace IsotopeOrdering.Domain.Entities {
    public class Item : ModelBase {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Unavailable { get; set; }
        [Required]
        public string Target { get; set; } = null!;
        [Required]
        public string Reaction { get; set; } = null!;
        [Required]
        public string FinalComposition { get; set; } = null!;
        [Required]
        public string SpecificActivity { get; set; } = null!;
        [Required]
        public string QualityControlAnalysis { get; set; } = null!;
        [Required]
        public decimal? MinQuantity { get; set; }
        [Required]
        public decimal? MaxQuantity { get; set; }

    }
}
