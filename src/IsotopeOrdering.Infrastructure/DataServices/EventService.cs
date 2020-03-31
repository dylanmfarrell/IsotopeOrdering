using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class EventService : IEventService {
        private readonly IsotopeOrderingDbContext _context;

        public EventService(IsotopeOrderingDbContext context) {
            _context = context;
        }

        public async Task CreateEvent(EntityEventType type, int id, string eventDescription, params object[] data) {
            string description = string.Format(eventDescription, data);
            _context.EntityEvents.Add(new EntityEvent() {
                EntityId = id,
                Type = type,
                Description = description
            });
            await _context.SaveChangesAsync();
        }

        public Task<List<EntityEvent>> GetEvents(int entityId) {
            return _context.EntityEvents.Where(x => x.EntityId == entityId).ToListAsync();
        }
    }
}
