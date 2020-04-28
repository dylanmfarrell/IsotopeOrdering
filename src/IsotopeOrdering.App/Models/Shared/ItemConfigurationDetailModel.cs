using MIR.Core.Domain;

namespace IsotopeOrdering.App.Models.Shared {
    public class ItemConfigurationDetailModel : ModelBase {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int? CustomerId { get; set; }
        public decimal Price { get; set; }
        public decimal? MinimumAmount { get; set; }
        public decimal? MaximumAmount { get; set; }
    }
}
