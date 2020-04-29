using MIR.Core.Domain;

namespace IsotopeOrdering.App.Models.Details {
    public class ItemDetailModel : ModelBase {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Unavailable { get; set; }
        public string Target { get; set; } = null!;
        public string Reaction { get; set; } = null!;
        public string FinalComposition { get; set; } = null!;
        public string? SpecificActivity { get; set; }
        public string? QualityControlAnalysis { get; set; }
        public decimal? MinQuantity { get; set; }
        public decimal? MaxQuantity { get; set; }
    }
}
