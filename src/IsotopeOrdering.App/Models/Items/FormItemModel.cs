using IsotopeOrdering.Domain.Enums;

namespace IsotopeOrdering.App.Models.Items {
    public class FormItemModel {
        public int Id { get; set; }
        public int CustomerDetailFormId { get; set; }
        public CustomerFormStatus Status { get; set; }
        public FormType Type { get; set; }
        public string Name { get; set; } = null!;
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();

    }
}
