using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class NotificationManagerTests {
        [Fact]
        public async void ProcessNotificationConfigurations_ReturnsNumberOfNotificationsCreated() {

        }

        [Fact]
        public async void ProcessNotificationConfiguration_ReturnsNumberOfNotificationsCreated() {

        }

        [Theory,AutoMoqData]
        public async void Send_Notifications_ReturnsSentCount(List<Notification> notifications) {
            Mock<INotificationService> mockNotificationService = new Mock<INotificationService>();
            mockNotificationService.Setup(x => x.GetNotificationsForProcessing()).ReturnsAsync(notifications);

            Mock<IEventService> mockEventService = new Mock<IEventService>();
            Mock<ICustomerService> mockCustomerService = new Mock<ICustomerService>();
            Mock<IShipmentService> mockShipmentService = new Mock<IShipmentService>();
            Mock<IOrderService> mockOrderService = new Mock<IOrderService>();
            Mock<ITemplateManager> mockTemplateManager = new Mock<ITemplateManager>();
            Mock<IEmailService> mockEmailService = new Mock<IEmailService>();

            NotificationManager manager = new NotificationManager(mockNotificationService.Object,
                mockEventService.Object,
                mockCustomerService.Object,
                mockShipmentService.Object,
                mockOrderService.Object,
                mockTemplateManager.Object,
                mockEmailService.Object);



            manager.SendNotifications();
        }

    }
}
