using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using MIR.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class InstitutionService : ServiceBase<IsotopeOrderingDbContext, Institution>, IInstitutionService {
        public InstitutionService(IsotopeOrderingDbContext context) : base(context) {

        }
        public Task<List<T>> GetListForInitiation<T>() {
            throw new NotImplementedException();
        }
    }
}
