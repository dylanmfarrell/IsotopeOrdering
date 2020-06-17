using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IsotopeOrdering.App.Models.Details {
    public class CustomerDetailModel : ModelBase {
        public ContactDetailModel Contact { get; set; } = new ContactDetailModel();
        public int? ParentCustomerId { get; set; }
        public string UserId { get; set; } = null!;
        public CustomerStatus Status { get; set; }
        public string? FedExNumber { get; set; }
        public List<CustomerAddressDetailModel> Addresses { get; set; } = new List<CustomerAddressDetailModel>();
        public List<CustomerDocumentDetailModel> Documents { get; set; } = new List<CustomerDocumentDetailModel>();
        public List<ItemConfigurationDetailModel> ItemConfigurations { get; set; } = new List<ItemConfigurationDetailModel>();
        public List<CustomerInstitutionDetailModel> Institutions { get; set; } = new List<CustomerInstitutionDetailModel>();
        public List<FormItemModel> Forms { get; set; } = new List<FormItemModel>();
        [DisplayName("Internal Notes")]
        public string? InternalNotes { get; set; } = string.Empty;
    }

    public class CustomerInstitutionDetailModel : ModelBase {
        public int CustomerId { get; set; }
        public int InstitutionId { get; set; }
        public InstitutionDetailModel Institution { get; set; } = new InstitutionDetailModel();
        public CustomerInstitutionRelationship Relationship { get; set; }
    }

    public class CustomerAddressDetailModel : ModelBase {
        public int CustomerId { get; set; }
        public AddressDetailModel Address { get; set; } = new AddressDetailModel();
        [DisplayName("Address Type")]
        public AddressType Type { get; set; }
        public bool IsShipping => Type == AddressType.Shipping;
        public bool IsBilling => Type == AddressType.Billing;
    }

    public class CustomerDocumentDetailModel : ModelBase {
        public int CustomerId { get; set; }
        public DocumentDetailModel Document { get; set; } = new DocumentDetailModel();
        [DisplayName("Expiration Date")]
        public DateTime? ExpirationDate { get; set; }
    }
}
