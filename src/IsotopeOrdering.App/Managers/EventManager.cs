using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class EventManager : IEventManager {
        private readonly IEventService _eventService;
        private readonly INotificationService _notificationService;

        public EventManager(IEventService eventService, INotificationService notificationService) {
            _eventService = eventService;
            _notificationService = notificationService;
        }

        public async Task CreateEvent(EntityEventType type, int id, string eventDescription) {
            await _eventService.CreateEvent(type, id, eventDescription);
            //TODO check event type, send notification based on event type
            //if type == x, _notificaitonService.SendNotification(...)
        }

        public async Task<List<EventItemModel>> GetEvents(EntityEventType type, int id) {
            return await _eventService.GetEvents<EventItemModel>(id, type);
        }
    }
}
