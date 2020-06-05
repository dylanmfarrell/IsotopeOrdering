using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IEventService {
        Task CreateEvent(EntityEventType type, int id, string eventDescription);
        Task<List<T>> GetEvents<T>(int entityId, EntityEventType type);
        Task<List<EntityEvent>> GetEvents(string eventDescription, DateTime? startDate);
    }
}
