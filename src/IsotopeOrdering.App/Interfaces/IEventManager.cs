using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IEventManager {
        Task CreateEvent(EntityEventType type, int id, string eventDescription);
        Task<List<EventItemModel>> GetEvents(EntityEventType type, int id);
    }
}
