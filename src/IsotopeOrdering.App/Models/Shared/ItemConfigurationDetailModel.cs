namespace IsotopeOrdering.App.Models.Shared {
    public class ItemConfigurationDetailModel {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int? CustomerId { get; set; }
        public decimal Price { get; set; }
        public decimal? MinimumAmount { get; set; }
        public decimal? MaximumAmount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
