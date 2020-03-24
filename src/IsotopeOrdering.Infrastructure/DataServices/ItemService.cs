using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using MIR.Core.Data;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class ItemService : ServiceBase<IsotopeOrderingDbContext, Item>, IItemService {
        public ItemService(IsotopeOrderingDbContext context) : base(context) {
        }
    }
}
