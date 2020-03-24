namespace IsotopeOrdering.Domain.Entities.Shared {
    public class Address {
        public string Name { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
    }
}
