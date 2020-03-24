using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsotopeOrdering.Domain.Entities {
    public class Customer : ModelBase {
        [Required]
        [StringLength(300, MinimumLength = 1)]
        public string Institution { get; set; } = null!;
        public CustomerStatus Status { get; set; } = CustomerStatus.Pending;
        public string? FedExNumber { get; set; }
        public ContactInformation CustomerInformation { get; set; } = null!;
        public ContactInformation RadiationSafetyInformation { get; set; } = null!;
        public ContactInformation FinancialDepartmentInformation { get; set; } = null!;
        public Address ShippingAddress { get; set; } = null!;
        public Address BillingAddress { get; set; } = null!;
        public List<ItemPrice> ItemPrices { get; set; } = new List<ItemPrice>();
    }
}
