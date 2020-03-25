using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class CustomerService : ServiceBase<IsotopeOrderingDbContext, Customer>, ICustomerService {
        private readonly IMapper _mapper;

        public CustomerService(IsotopeOrderingDbContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetList<T>() {
            return await _mapper.ProjectTo<T>(_context.Customers).ToListAsync();
        }
    }
}
