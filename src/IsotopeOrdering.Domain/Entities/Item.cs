using MIR.Core.Domain;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class Item : ModelBase {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Unavailable { get; set; }
        public string Target { get; set; } = null!;
        public string Reaction { get; set; } = null!;
        public string FinalComposition { get; set; } = null!;
        public string SpecificActivity { get; set; } = null!;
        public string QualityControlAnalysis { get; set; } = null!;
        public decimal? MinQuantity { get; set; }
        public decimal? MaxQuantity { get; set; }
        public List<ItemConfiguration> ItemConfigurations { get; set; } = new List<ItemConfiguration>();
    }
}
