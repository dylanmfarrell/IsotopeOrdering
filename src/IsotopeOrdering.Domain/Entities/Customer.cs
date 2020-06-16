using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class Customer : ModelBase {
        public string UserId { get; set; } = null!;
        public int? ParentCustomerId { get; set; }
        public Customer? ParentCustomer { get; set; }
        public CustomerStatus Status { get; set; } = CustomerStatus.Pending;
        public string? FedExNumber { get; set; }
        public Contact Contact { get; set; } = new Contact();
        public List<CustomerAddress> Addresses { get; set; } = new List<CustomerAddress>();
        public List<CustomerDocument> Documents { get; set; } = new List<CustomerDocument>();
        public List<ItemConfiguration> ItemConfigurations { get; set; } = new List<ItemConfiguration>();
        public List<CustomerInstitution> Institutions { get; set; } = new List<CustomerInstitution>();
        public List<CustomerForm> Forms { get; set; } = new List<CustomerForm>();
        public string? InternalNotes { get; set; }
    }
}
