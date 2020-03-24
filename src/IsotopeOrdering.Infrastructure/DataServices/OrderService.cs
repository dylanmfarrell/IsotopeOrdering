using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using MIR.Core.Data;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class OrderService : ServiceBase<IsotopeOrderingDbContext, Order>, IOrderService {
        public OrderService(IsotopeOrderingDbContext context) : base(context) {
        }
    }
}
