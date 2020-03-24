using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IEventService {
        Task CreateStatusUpdateEvent(EntityEventType type, int id, Enum currentStatus, Enum newStatus);
        Task CreateDataUpdateEvent(EntityEventType type, int id, string currentData, string newData);
        Task<IEnumerable<EntityEvent>> GetEvents(EntityEventType type, int id);
    }
}
