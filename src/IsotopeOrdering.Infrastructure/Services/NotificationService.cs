using IsotopeOrdering.Domain.Interfaces;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class NotificationService : INotificationService {
        public async Task<bool> SendNotification(string recipientName, string recipientEmail, string title, string message) {
            return await Task.FromResult(true);
        }
    }
}
