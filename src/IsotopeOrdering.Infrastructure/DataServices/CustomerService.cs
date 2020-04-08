using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class CustomerService : ServiceBase<IsotopeOrderingDbContext, Customer>, ICustomerService {
        private readonly IMapper _mapper;

        public CustomerService(IsotopeOrderingDbContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public async Task<T?> Get<T>(string email) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Where(x => x.Contact.Email == email)).SingleOrDefaultAsync();
        }

        public async Task<T> Get<T>(int id) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Where(x => x.Id == id)).SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetChildrenList<T>(int parentId) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Where(x => x.ParentCustomerId == parentId))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<T>> GetList<T>() where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<T>> GetAddressListForOrder<T>(int customerId, int? parentCustomerId) {
            return await _mapper.ProjectTo<T>(_context.CustomerAddresses.Where(x => x.CustomerId == parentCustomerId.GetValueOrDefault(customerId))).ToListAsync();
        }
    }
}
