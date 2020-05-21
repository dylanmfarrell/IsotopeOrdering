using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class InstitutionService : ServiceBase<IsotopeOrderingDbContext, Institution>, IInstitutionService {
        private readonly IMapper _mapper;

        public InstitutionService(IsotopeOrderingDbContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public async Task<T?> GetInstitutionForCustomer<T>(int customerId) where T : class {
            return await _mapper.ProjectTo<T>(
                _context.Institutions
                .Include(x => x.Customers)
                .Where(x => x.Customers.Any(x => x.CustomerId == customerId))
                ).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListForInitiation<T>() {
            return await _mapper.ProjectTo<T>(_context.Institutions).ToListAsync();
        }
    }
}
