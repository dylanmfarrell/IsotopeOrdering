﻿using IsotopeOrdering.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IEventService {
        Task CreateEvent(EntityEventType type, int id, string eventDescription);
        Task<List<T>> GetEvents<T>(int entityId, EntityEventType type);
    }
}
