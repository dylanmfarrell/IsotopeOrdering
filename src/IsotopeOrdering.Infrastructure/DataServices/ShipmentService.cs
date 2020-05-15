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
    public class ShipmentService : ServiceBase<IsotopeOrderingDbContext, Shipment>, IShipmentService {
        private readonly IMapper _mapper;

        public ShipmentService(IMapper mapper, IsotopeOrderingDbContext context) : base(context) {
            _mapper = mapper;
        }

        public async Task<T?> Get<T>(int id) where T : class {
            return await _mapper.ProjectTo<T>(
                _context.Shipments
                .Include(x => x.Items)
                    .ThenInclude(x => x.OrderItem)
                        .ThenInclude(x => x.ItemConfiguration)
                .Where(x => x.Id == id)
                ).SingleOrDefaultAsync();
        }

        public async Task<T?> Get<T>(int id, int customerId, int? parentId) where T : class {
            return await _mapper.ProjectTo<T>(
                _context.Shipments
                .Include(x => x.Items)
                    .ThenInclude(x => x.OrderItem)
                        .ThenInclude(x => x.ItemConfiguration)
                .Include(x => x.Items)
                    .ThenInclude(x => x.OrderItem)
                        .ThenInclude(x => x.Order)
                .Where(x => x.Id == id 
                    && x.Items.Select(x => x.OrderItem).All(x => x.Order.CustomerId == parentId.GetValueOrDefault(customerId)))
                ).SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetList<T>() {
            throw new System.NotImplementedException();
        }

        public async Task<List<T>> GetListForCustomer<T>(int customerId, int? parentId) {
            throw new System.NotImplementedException();
        }

        public async Task UpdateStatus(int orderId, ShipmentStatus status) {
            throw new System.NotImplementedException();
        }
    }
}
