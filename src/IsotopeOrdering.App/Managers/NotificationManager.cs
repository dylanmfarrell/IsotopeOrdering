using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Notifications;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class NotificationManager : INotificationManager {
        private readonly INotificationService _service;
        private readonly IEventService _eventService;
        private readonly ICustomerService _customerService;
        private readonly IShipmentService _shipmentService;
        private readonly IOrderService _orderService;
        private readonly ITemplateManager _templateManager;
        private readonly IEmailService _emailService;

        public NotificationManager(
            INotificationService service,
            IEventService eventService,
            ICustomerService customerService,
            IShipmentService shipmentService,
            IOrderService orderService,
            ITemplateManager templateManager,
            IEmailService emailService) {
            _service = service;
            _eventService = eventService;
            _customerService = customerService;
            _shipmentService = shipmentService;
            _orderService = orderService;
            _templateManager = templateManager;
            _emailService = emailService;
        }

        public async Task<int> SendNotifications() {
            List<Notification> notifications = await _service.GetNotificationsForProcessing();
            Dictionary<int, bool> notificationsSent = await _emailService.Send(notifications);
            List<int> notificationIdsSent = notificationsSent.ToList().Where(x => x.Value).Select(x => x.Key).ToList();
            await _service.UpdateSentDates(notificationIdsSent);
            return notificationIdsSent.Count();
        }

        public async Task<int> ProcessNotificationConfigurations() {
            int processedNotificationsCount = 0;
            List<NotificationConfiguration> notificationConfigurations = await _service.GetNotificationConfigurations();
            foreach (NotificationConfiguration notificationConfiguration in notificationConfigurations) {
                processedNotificationsCount += await ProcessNotificationConfiguration(notificationConfiguration);
            }
            return processedNotificationsCount;
        }

        public async Task<int> ProcessNotificationConfiguration(NotificationConfiguration notificationConfiguration) {
            int processedNotificationsCount = 0;
            List<EntityEvent> events = await _eventService.GetEvents(notificationConfiguration.EventTrigger, notificationConfiguration.LastProcessed);
            foreach (EntityEvent entityEvent in events) {
                NotificationDto notificationDto = await GetNotificationDto(notificationConfiguration, entityEvent);
                processedNotificationsCount += await _service.CreateNotifications(notificationDto.ToNotifications());
            }
            await _service.UpdateLastProcessedDate(notificationConfiguration.Id);
            return processedNotificationsCount;
        }

        public async Task<NotificationDto> GetNotificationDto(NotificationConfiguration notificationConfiguration, EntityEvent entityEvent) {
            NotificationDto notificationDto = new NotificationDto(entityEvent, notificationConfiguration.Subscriptions, notificationConfiguration.Title);
            notificationDto.AddRecipients(await GetRecipients(notificationConfiguration.Target, entityEvent));
            notificationDto.Body = await _templateManager.GetContent(notificationConfiguration.Target, notificationConfiguration.TemplatePath, entityEvent);
            return notificationDto;
        }

        private async Task<List<RecipientDto>> GetRecipients(NotificationTarget notificationTarget, EntityEvent entityEvent) {
            if (notificationTarget == NotificationTarget.Customer) {
                return await GetRecipientsForEvent(entityEvent);
            }
            if (notificationTarget == NotificationTarget.Admin) {
                //TODO: get admin recipients
                return new List<RecipientDto>();
            }
            if (notificationTarget == NotificationTarget.External) {
                //TODO: get external recipients
                return new List<RecipientDto>();
            }
            return new List<RecipientDto>();
        }

        private async Task<List<RecipientDto>> GetRecipientsForEvent(EntityEvent entityEvent) {
            return entityEvent.Type switch
            {
                EntityEventType.Customer => await _customerService.GetRecipients<RecipientDto>(entityEvent.EntityId),
                EntityEventType.Order => await _orderService.GetRecipients<RecipientDto>(entityEvent.EntityId),
                EntityEventType.Shipping => await _shipmentService.GetRecipients<RecipientDto>(entityEvent.EntityId),
                _ => new List<RecipientDto>(),
            };
        }
    }
}
