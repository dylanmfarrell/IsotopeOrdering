using System.ComponentModel;

namespace IsotopeOrdering.App.Models.Shared {
    public class AddressDetailModel {
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
    }
}
