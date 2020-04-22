using IsotopeOrdering.Domain.Enums;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IEventManager {
        Task CreateEvent(EntityEventType type, int id, string eventDescription);
    }
}
