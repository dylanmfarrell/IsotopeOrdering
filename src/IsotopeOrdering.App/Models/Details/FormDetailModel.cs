using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class FormDetailModel {
        public int Id { get; set; }
        public FormType Type { get; set; }
        public string Name { get; set; } = null!;
        public int CustomerDetailFormId { get; set; }
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public CustomerFormStatus CustomerFormStatus { get; set; }
        public FormInitiationDetailModel? InitiationModel { get; set; }
    }

    public class FormInitiationDetailModel {
        public List<InstitutionItemModel> Institutions { get; set; } = new List<InstitutionItemModel>();
        public InstitutionItemModel? SelectedInstitution { get; set; }
        public AddressDetailModel ShippingAddress { get; set; } = new AddressDetailModel();
        public List<FormInitiationItemModel> Items { get; set; } = new List<FormInitiationItemModel>();
    }

    public class FormInitiationItemModel {
        public bool IsSelected { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Unavailable { get; set; }
        public string Target { get; set; } = null!;
        public string Reaction { get; set; } = null!;
        public string FinalComposition { get; set; } = null!;
        public string SpecificActivity { get; set; } = null!;
        public string QualityControlAnalysis { get; set; } = null!;
    }
}
