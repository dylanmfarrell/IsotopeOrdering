using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class FormDetailModel {
        public int Id { get; set; }
        public FormType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CustomerDetailFormId { get; set; }
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public CustomerFormStatus CustomerFormStatus { get; set; }
        public string? FormData { get; set; }
        public FormInitiationDetailModel? InitiationModel { get; set; }
        public bool RequiresEmailForOtm => CustomerFormStatus == CustomerFormStatus.Assigned;
        public bool RequiresSignatureFromOtm => CustomerFormStatus == CustomerFormStatus.AwaitingSignature;
        public bool ShowSignatureFromOtm => CustomerFormStatus > CustomerFormStatus.AwaitingSignature;
        public bool RequiresSignatureFromAdmin => CustomerFormStatus == CustomerFormStatus.SignedBySafetyContact;
        public bool ShowSignatureFromAdmin => CustomerFormStatus == CustomerFormStatus.Completed;
        public bool CanEdit => CustomerFormStatus != CustomerFormStatus.Approved && CustomerFormStatus != CustomerFormStatus.Denied;
    }

    public class FormInitiationDetailModel {
        public Guid FormIdentifier { get; set; } = Guid.NewGuid();
        public InstitutionDetailModel Institution { get; set; } = new InstitutionDetailModel();
        public AddressDetailModel ShippingAddress { get; set; } = new AddressDetailModel();
        public string FedExNumber { get; set; } = string.Empty;
        public List<FormInitiationItemModel> Items { get; set; } = new List<FormInitiationItemModel>();
        public FormInitiationSignatureModel OtmSignature { get; set; } = new FormInitiationSignatureModel();
        public FormInitiationSignatureModel AdminSignature { get; set; } = new FormInitiationSignatureModel();
    }

    public class FormInitiationItemModel {
        public bool IsSelected { get; set; }
        public ItemDetailModel Item { get; set; } = new ItemDetailModel();
    }

    public class FormInitiationSignatureModel {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PrintedName { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
