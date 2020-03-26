using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using MIR.Core.Data;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class FormService : ServiceBase<IsotopeOrderingDbContext, Form>, IFormService {
        public FormService(IsotopeOrderingDbContext context) : base(context) {
        }
    }
}
