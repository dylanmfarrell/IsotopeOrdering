﻿using IsotopeOrdering.App.Models.Shared;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class ItemDetailModel {
        public int Id { get; set; }
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
    }
}
