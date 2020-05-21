using IsotopeOrdering.Infrastructure.Services;
using Xunit;

namespace IsotopeOrdering.Infrastructure.IntegrationTests.Services {
    public class NotificationServiceTests {
        [Theory, AutoMoqData]
        public async void Send_Notification(string recipient, string email, string title, string content) {
            NotificationService service = new NotificationService();
            Assert.True(await service.SendNotification(recipient, email, title, content));
        }
    }
}
