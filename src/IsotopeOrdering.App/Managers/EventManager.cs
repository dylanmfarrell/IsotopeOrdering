using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class EventManager : IEventManager {
        private readonly IEventService _eventService;

        public EventManager(IEventService eventService) {
            _eventService = eventService; 
        }

        public async Task CreateEvent(EntityEventType type, int id, string eventDescription) {
            await _eventService.CreateEvent(type, id, eventDescription);
        }

        public async Task<List<EventItemModel>> GetEvents(EntityEventType type, int id) {
            return await _eventService.GetEvents<EventItemModel>(id, type);
        }
    }
}
