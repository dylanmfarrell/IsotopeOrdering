using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class Customer : ModelBase {
        public CustomerStatus Status { get; set; } = CustomerStatus.Pending;
        public string? FedExNumber { get; set; }
        public Contact CustomerContact { get; set; } = null!;
        public Address Shipping { get; set; } = null!;
        public Address Billing { get; set; } = null!;
        public List<ItemConfiguration> ItemPrices { get; set; } = new List<ItemConfiguration>();
        public List<CustomerInstitution> Institutions { get; set; } = new List<CustomerInstitution>();
        public Guid UploadId { get; set; }
    }
}
