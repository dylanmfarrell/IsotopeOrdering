using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Notifications;
using IsotopeOrdering.Domain;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class NotificationManager : INotificationManager {
        private readonly ILogger<NotificationManager> _logger;
        private readonly INotificationService _service;
        private readonly IEventService _eventService;
        private readonly ICustomerService _customerService;
        private readonly IShipmentService _shipmentService;
        private readonly IOrderService _orderService;
        private readonly ITemplateManager _templateManager;
        private readonly IEmailService _emailService;

        public NotificationManager(
            ILogger<NotificationManager> logger,
            INotificationService service,
            IEventService eventService,
            ICustomerService customerService,
            IShipmentService shipmentService,
            IOrderService orderService,
            ITemplateManager templateManager,
            IEmailService emailService) {
            _logger = logger;
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
                NotificationDto notificationDto;
                if (TryGetNotificationDto(notificationConfiguration, entityEvent, out notificationDto)) {
                    processedNotificationsCount += await _service.CreateNotifications(notificationDto.ToNotifications());
                }
            }
            if (processedNotificationsCount > 0) {
                await _service.UpdateLastProcessedDate(notificationConfiguration.Id);
            }
            return processedNotificationsCount;
        }

        public async Task<List<NotificationConfigurationItemModel>> GetNotificationConfigurations(NotificationTarget target) {
            return await _service.GetConfigurationList<NotificationConfigurationItemModel>(target);
        }

        private bool TryGetNotificationDto(NotificationConfiguration notificationConfiguration, EntityEvent entityEvent, out NotificationDto notificationDto) {
            notificationDto = new NotificationDto(entityEvent, notificationConfiguration.Subscriptions, notificationConfiguration.Title);
            try {
                notificationDto.AddRecipients(GetRecipients(notificationConfiguration.Target, entityEvent).Result);
                notificationDto.Body = _templateManager.GetContent(notificationConfiguration.Target, notificationConfiguration.TemplatePath, entityEvent).Result;
                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to process notification configuration {notificationConfiguration}", notificationConfiguration);
            }
            return false;
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
