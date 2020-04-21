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
    }

    public class FormInitiationDetailModel {
        public InstitutionDetailModel Institution { get; set; } = new InstitutionDetailModel();
        public AddressDetailModel ShippingAddress { get; set; } = new AddressDetailModel();
        public string FedExNumber { get; set; } = string.Empty;
        public List<FormInitiationItemModel> Items { get; set; } = new List<FormInitiationItemModel>();
        public string Signature { get; set; } = string.Empty;
        public string SignaturePrintedName { get; set; } = string.Empty;
        public DateTime SignatureDate { get; set; } = DateTime.Now;
    }

    public class FormInitiationItemModel {
        public bool IsSelected { get; set; }
        public ItemDetailModel Item { get; set; } = new ItemDetailModel();
    }
}
