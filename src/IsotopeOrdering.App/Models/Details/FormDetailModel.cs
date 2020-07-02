using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class FormDetailModel : ModelBase {
        public FormType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CustomerDetailFormId { get; set; }
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public CustomerFormStatus CustomerFormStatus { get; set; }
        public Guid FormIdentifier { get; set; } = Guid.NewGuid();
        public string? FormData { get; set; }
        public FormInitiationDetailModel? InitiationModel { get; set; }
        public CustomerFormStatus Action { get; set; }
        public bool AllowSignatureFromCustomerAdmin { get; set; }
        public bool RequiresEmailForCustomerAdmin => CustomerFormStatus == CustomerFormStatus.New;
        public bool RequiresSignatureFromCustomerAdmin => CustomerFormStatus == CustomerFormStatus.AwaitingCustomerSupervisorApproval && AllowSignatureFromCustomerAdmin;
        public bool ShowSignatureFromCustomerAdmin => CustomerFormStatus == CustomerFormStatus.AwaitingAdminApproval;
        public bool RequiresSignatureFromAdmin => CustomerFormStatus == CustomerFormStatus.AwaitingAdminApproval;
        public bool ShowSignatureFromAdmin => CustomerFormStatus == CustomerFormStatus.Approved;
        public bool CanEdit => CustomerFormStatus != CustomerFormStatus.Approved && CustomerFormStatus != CustomerFormStatus.Denied;
    }

    public class FormInitiationDetailModel {
        public InstitutionDetailModel Institution { get; set; } = new InstitutionDetailModel();
        public AddressDetailModel ShippingAddress { get; set; } = new AddressDetailModel();
        public string? FedExNumber { get; set; } = string.Empty;
        public List<FormInitiationItemModel> Items { get; set; } = new List<FormInitiationItemModel>();
        public FormInitiationSignatureModel CustomerAdminSignature { get; set; } = new FormInitiationSignatureModel();
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
        public string? Position { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
