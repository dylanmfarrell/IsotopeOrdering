using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.App.Models.Items {
    public class OrderItemModel:ModelBase {
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public OrderStatus Status { get; set; }
    }
}
