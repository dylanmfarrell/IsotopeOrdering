using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class ItemService : ServiceBase<IsotopeOrderingDbContext, Item>, IItemService {
        private readonly IMapper _mapper;

        public ItemService(IsotopeOrderingDbContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public async Task<T> Get<T>(int id) {
            return await _mapper.ProjectTo<T>(_context.Items.Where(x => x.Id == id)).SingleAsync();
        }

        public async Task<List<ItemConfiguration>> GetItemConfigurations(int itemId, int customerId) {
            List<ItemConfiguration> itemConfigurations = await _context.ItemConfigurations.Where(x => x.ItemId == itemId && x.CustomerId == customerId).ToListAsync();
            ItemConfiguration defaultConfiguration = await _context.ItemConfigurations.FirstOrDefaultAsync(x => x.ItemId == itemId && x.CustomerId == null);
            itemConfigurations.Add(defaultConfiguration);
            return itemConfigurations;
        }

        public async Task<List<T>> GetList<T>() {
            return await _mapper.ProjectTo<T>(_context.Items).ToListAsync();
        }

        public async Task<List<T>> GetListForInitiation<T>() {
            return await _mapper.ProjectTo<T>(_context.Items.Where(x => !x.Unavailable)).ToListAsync();
        }

        public async Task<List<T>> GetListForOrder<T>(int customerId, int? parentCustomerId) {
            return await _mapper.ProjectTo<T>(
                _context.Items
                .Include(x => x.ItemConfigurations)
                .Where(x => x.ItemConfigurations.Any(y => y.CustomerId == parentCustomerId.GetValueOrDefault(customerId)))
                .AsNoTracking()
                ).ToListAsync();
        }
    }
}
