using MIR.Core.Domain;
using System.ComponentModel;

namespace IsotopeOrdering.App.Models.Details {
    public class ItemDetailModel : ModelBase {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Unavailable { get; set; }
        public string Target { get; set; } = null!;
        public string Reaction { get; set; } = null!;
        [DisplayName("Final Composition")]
        public string FinalComposition { get; set; } = null!;
        [DisplayName("Specific Activity")]
        public string? SpecificActivity { get; set; }
        [DisplayName("Quality Control Analysis")]
        public string? QualityControlAnalysis { get; set; }
        [DisplayName("Default Price")]
        public decimal? DefaultPrice { get; set; }
        [DisplayName("Default Min Quantity")]
        public decimal? DefaultMinQuantity { get; set; }
        [DisplayName("Default Max Quantity")]
        public decimal? DefaultMaxQuantity { get; set; }
    }
}
