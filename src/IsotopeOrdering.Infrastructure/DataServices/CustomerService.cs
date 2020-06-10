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

        public async Task<T?> GetCurrentCustomer<T>() where T : class {
            return await Get<T>(_context.UserService.User.EducationId);
        }

        public async Task<T?> Get<T>(string userId) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Where(x => x.UserId == userId))
                .SingleOrDefaultAsync();
        }

        public async Task<T> Get<T>(int id) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Details().Where(x => x.Id == id)).SingleOrDefaultAsync();
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

        public async Task<List<T>> GetAddressListForOrder<T>(int customerId, int? parentCustomerId) where T : class {
            int targetCustomerId = parentCustomerId.GetValueOrDefault(customerId);
            List<T> customerAddresses = await _mapper.ProjectTo<T>(_context.CustomerAddresses.Where(x => x.CustomerId == targetCustomerId)).AsNoTracking().ToListAsync();
            List<T> institutionAddresses = await _mapper.ProjectTo<T>(_context.CustomerInstitutions.Include(x => x.Institution).Where(x => x.CustomerId == targetCustomerId)).AsNoTracking().ToListAsync();
            customerAddresses.AddRange(institutionAddresses);
            return customerAddresses;
        }

        public async Task<T> GetChild<T>(int parentId, int childId) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Where(x => x.Id == childId && x.ParentCustomerId.HasValue && x.ParentCustomerId.Value == parentId))
                .SingleOrDefaultAsync();
        }

        public async Task<List<T>> Search<T>(string search) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Search(search).AsNoTracking()).ToListAsync();
        }

        public async Task<List<T>> GetRecipients<T>(int id) where T : class {
            Customer customer = await _context.Customers.FindAsync(id);
            return _mapper.Map<List<T>>(customer);
        }
    }
}
