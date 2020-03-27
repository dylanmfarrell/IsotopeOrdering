using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class CustomerDetailModel {
        public int Id { get; set; }
        public ContactDetailModel Contact { get; set; } = new ContactDetailModel();
        public int? ParentCustomerId { get; set; }
        public CustomerStatus Status { get; set; }
        public List<CustomerAddressDetailModel> Addresses = new List<CustomerAddressDetailModel>();
        public List<CustomerDocumentDetailModel> Documents = new List<CustomerDocumentDetailModel>();
        public List<ItemConfigurationDetailModel> ItemConfigurations { get; set; } = new List<ItemConfigurationDetailModel>();
        public List<CustomerInstitutionDetailModel> Institutions { get; set; } = new List<CustomerInstitutionDetailModel>();
        public string InternalNotes { get; set; } = null!;
    }

    public class CustomerInstitutionDetailModel {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int InstitutionId { get; set; }
        public InstitutionDetailModel Institution { get; set; } = new InstitutionDetailModel();
        public CustomerInstitutionRelationship Relationship { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class CustomerAddressDetailModel {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public AddressDetailModel Address { get; set; } = new AddressDetailModel();
        public AddressType Type { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class CustomerDocumentDetailModel {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DocumentDetailModel Document { get; set; } = new DocumentDetailModel();
        public DateTime? ExpirationDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}
