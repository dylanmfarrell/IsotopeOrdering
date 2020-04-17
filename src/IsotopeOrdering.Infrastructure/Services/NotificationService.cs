using IsotopeOrdering.Domain.Interfaces;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class NotificationService : INotificationService {
        public async Task SendNotification(string recipientName, string recipientEmail, string message) {
            await Task.CompletedTask;
        }
    }
}
