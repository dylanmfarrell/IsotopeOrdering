using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class EventService : IEventService {
        private readonly IsotopeOrderingDbContext _context;

        public EventService(IsotopeOrderingDbContext context) {
            _context = context;
        }

        public Task CreateDataUpdateEvent(EntityEventType type, int id, string currentData, string newData) {
            throw new NotImplementedException();
        }

        public Task CreateStatusUpdateEvent(EntityEventType type, int id, Enum currentStatus, Enum newStatus) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntityEvent>> GetEvents(EntityEventType type, int id) {
            throw new NotImplementedException();
        }
    }
}
