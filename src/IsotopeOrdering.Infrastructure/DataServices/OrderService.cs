using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class OrderService : ServiceBase<IsotopeOrderingDbContext, Order>, IOrderService {
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IsotopeOrderingDbContext context) : base(context) {
            _mapper = mapper;
        }

        public async Task<T?> Get<T>(int id) where T : class {
            return await _mapper.ProjectTo<T>(
                _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .ThenInclude(x => x.ItemConfiguration)
                .Where(x => x.Id == id)
                ).SingleOrDefaultAsync();
        }

        public async Task<T?> GetForReview<T>(int id) where T : class {
            return await _mapper.ProjectTo<T>(
                _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .ThenInclude(x => x.ItemConfiguration)
                .Where(x => x.Id == id && x.Status == OrderStatus.Sent)
                ).SingleOrDefaultAsync();
        }

        public async Task<T?> Get<T>(int id, int customerId, int? parentId) where T : class {
            return await _mapper.ProjectTo<T>(
                _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .ThenInclude(x => x.ItemConfiguration)
                .Where(x => x.Id == id && x.CustomerId == parentId.GetValueOrDefault(customerId))
                ).SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetList<T>() {
            return await _mapper.ProjectTo<T>(
                _context.Orders
                .Include(x => x.Customer)
                ).ToListAsync();
        }

        public async Task<List<T>> GetListForCustomer<T>(int customerId, int? parentId) {
            return await _mapper.ProjectTo<T>(
                _context.Orders
                .Include(x => x.Customer)
                .Where(x => x.CustomerId == customerId || x.CustomerId == parentId.GetValueOrDefault(0)))
                .ToListAsync();
        }

        public async Task UpdateStatus(int orderId, OrderStatus status) {
            Order order = await _context.Orders.FindAsync(orderId);
            order.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
