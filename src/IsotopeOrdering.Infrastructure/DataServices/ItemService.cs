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

        public async Task<List<T>> GetList<T>() {
            return await _mapper.ProjectTo<T>(_context.Items).ToListAsync();
        }

        public async Task<List<T>> GetListForInitiation<T>() {
            return await _mapper.ProjectTo<T>(_context.Items.Where(x => !x.Unavailable)).ToListAsync();
        }
    }
}
