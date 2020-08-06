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
            return await _mapper.ProjectTo<T>(_context.Shipments.Details().Where(x => x.Id == id)).SingleOrDefaultAsync();
        }

        public async Task<T?> Get<T>(int id, int customerId, int? parentId) where T : class {
            return await _mapper.ProjectTo<T>(_context.Shipments.Details().WhereForCustomer(customerId, parentId).Where(x => x.Id == id)).SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetForOrder<T>(int orderId) where T : class {
            return await _mapper.ProjectTo<T>(_context.Shipments.Details().WhereForOrder(orderId).AsNoTracking()).ToListAsync();
        }

        public async Task<List<T>> GetList<T>() {
            return await _mapper.ProjectTo<T>(_context.Shipments.Details().AsNoTracking()).ToListAsync();
        }

        public async Task<List<T>> GetListForCustomer<T>(int customerId, int? parentId) {
            return await _mapper.ProjectTo<T>(_context.Shipments.Details().WhereForCustomer(customerId, parentId).AsNoTracking()).ToListAsync();
        }

        public async Task UpdateStatus(int id, ShipmentStatus status) {
            Shipment shipment = await _context.Shipments.FindAsync(id);
            shipment.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetRecipients<T>(int id) where T : class {
            Shipment shipment = await _context.Shipments
                .Include(x => x.Items)
                    .ThenInclude(x => x.OrderItem)
                        .ThenInclude(x => x.Order)
                            .ThenInclude(x => x.Customer)
                .FirstAsync(x => x.Id == id);
            Customer customer = shipment.Items.First().OrderItem.Order.Customer;
            return new List<T>() { _mapper.Map<T>(customer) };
        }

        public async Task<List<T>> GetList<T>(ShipmentStatus status) {
            return await _mapper.ProjectTo<T>(_context.Shipments.Details().Where(x => x.Status == status)).ToListAsync();
        }
    }
}