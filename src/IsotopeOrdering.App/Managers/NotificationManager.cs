using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Notifications;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class NotificationManager : INotificationManager {
        private readonly INotificationService _service;
        private readonly IEventService _eventService;
        private readonly ICustomerService _customerService;
        private readonly IShipmentService _shipmentService;
        private readonly IOrderService _orderService;

        public NotificationManager(INotificationService service,
            IEventService eventService,
            ICustomerService customerService,
            IShipmentService shipmentService,
            IOrderService orderService) {
            _service = service;
            _eventService = eventService;
            _customerService = customerService;
            _shipmentService = shipmentService;
            _orderService = orderService;
        }

        public async Task ProcessNotifications() {
            List<Notification> notifications = await _service.GetNotifications();
            foreach (Notification notification in notifications) {
                await ProcessNotification(notification);
            }
        }

        public async Task ProcessNotification(Notification notification) {
            List<EntityEvent> events = await _eventService.GetEvents(notification.EventTrigger, notification.LastProcessed);
            if (notification.Target == NotificationTarget.Customer) {
                foreach (EntityEvent entityEvent in events) {

                }
            }
        }

        public async Task<List<Recipient>> GetRecipientsForEvent(EntityEvent entityEvent) {
            return entityEvent.Type switch
            {
                EntityEventType.Customer => await _customerService.GetRecipients<Recipient>(entityEvent.EntityId),
                EntityEventType.Order => await _orderService.GetRecipients<Recipient>(entityEvent.EntityId),
                EntityEventType.Shipping => await _shipmentService.GetRecipients<Recipient>(entityEvent.EntityId),
                _ => new List<Recipient>(),
            };
        }
    }
}
