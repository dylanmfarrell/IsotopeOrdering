using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using MIR.Core.Data;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class CustomerService : ServiceBase<IsotopeOrderingDbContext, Customer>, ICustomerService {
        public CustomerService(IsotopeOrderingDbContext context) : base(context) {
        }
    }
}
