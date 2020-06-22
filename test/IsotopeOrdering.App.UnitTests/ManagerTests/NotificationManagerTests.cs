using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Models.Notifications;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Entities.Shared;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class NotificationManagerTests {
        [Theory, AutoMoqData]
        public async void ProcessNotificationConfiguration_ReturnsNumberOfNotificationsCreated(NotificationConfiguration notificationConfiguration, List<RecipientDto> recipients, List<EntityEvent> entityEvents) {
            entityEvents.ForEach(x => x.EventDateTime = DateTime.Now);
            entityEvents.ForEach(x => x.Type = EntityEventType.Customer);

            notificationConfiguration.Subscriptions = recipients.Select(x => new NotificationSubscription() {
                Customer = new Customer() {
                    Contact = new Contact() {
                        Email = x.EmailAddress,
                        FirstName = x.Name
                    }
                },
            }).ToList();
            notificationConfiguration.EventTrigger = entityEvents.First().Description;
            notificationConfiguration.LastProcessed = DateTime.Now.AddHours(-1);
            notificationConfiguration.Target = NotificationTarget.Customer;

            Mock<INotificationService> mockNotificationService = new Mock<INotificationService>();
            mockNotificationService.Setup(x => x.UpdateLastProcessedDate(It.IsAny<int>())).Returns(Task.CompletedTask);
            mockNotificationService.Setup(x => x.CreateNotifications(It.IsAny<List<Notification>>())).ReturnsAsync(recipients.Count);

            Mock<IEventService> mockEventService = new Mock<IEventService>();
            mockEventService.Setup(x => x.GetEvents(It.IsAny<string>(), It.IsAny<DateTime>())).ReturnsAsync(entityEvents);

            Mock<IEmailService> mockEmailService = new Mock<IEmailService>();
            Mock<ICustomerService> mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(x => x.GetRecipients<RecipientDto>(It.IsAny<int>())).ReturnsAsync(recipients);

            Mock<IShipmentService> mockShipmentService = new Mock<IShipmentService>();
            Mock<IOrderService> mockOrderService = new Mock<IOrderService>();
            Mock<ITemplateManager> mockTemplateManager = new Mock<ITemplateManager>();
            mockTemplateManager.Setup(x => x.GetContent(It.IsAny<NotificationTarget>(), It.IsAny<string>(), It.IsAny<EntityEvent>())).ReturnsAsync(string.Empty);

            NotificationManager manager = new NotificationManager(
                new NullLogger<NotificationManager>(),
                mockNotificationService.Object,
                mockEventService.Object,
                mockCustomerService.Object,
                mockShipmentService.Object,
                mockOrderService.Object,
                mockTemplateManager.Object,
                mockEmailService.Object);

            Assert.Equal(entityEvents.Count * recipients.Count, await manager.ProcessNotificationConfiguration(notificationConfiguration));
        }

        [Theory, AutoMoqData]
        public async void Send_Notifications_ReturnsSentCount(List<Notification> notifications) {
            Mock<INotificationService> mockNotificationService = new Mock<INotificationService>();
            mockNotificationService.Setup(x => x.GetNotificationsForProcessing()).ReturnsAsync(notifications);
            mockNotificationService.Setup(x => x.UpdateSentDates(It.IsAny<List<int>>())).Returns(Task.CompletedTask);

            Mock<IEmailService> mockEmailService = new Mock<IEmailService>();
            Dictionary<int, bool> notificationsSent = new Dictionary<int, bool>(notifications.Select(x => new KeyValuePair<int, bool>(x.Id, true)));
            mockEmailService.Setup(x => x.Send(It.IsAny<List<Notification>>())).ReturnsAsync(notificationsSent);

            Mock<IEventService> mockEventService = new Mock<IEventService>();
            Mock<ICustomerService> mockCustomerService = new Mock<ICustomerService>();
            Mock<IShipmentService> mockShipmentService = new Mock<IShipmentService>();
            Mock<IOrderService> mockOrderService = new Mock<IOrderService>();
            Mock<ITemplateManager> mockTemplateManager = new Mock<ITemplateManager>();

            NotificationManager manager = new NotificationManager(
                new NullLogger<NotificationManager>(),
                mockNotificationService.Object,
                mockEventService.Object,
                mockCustomerService.Object,
                mockShipmentService.Object,
                mockOrderService.Object,
                mockTemplateManager.Object,
                mockEmailService.Object);

            Assert.Equal(notifications.Count, await manager.SendNotifications());
        }

    }
}
