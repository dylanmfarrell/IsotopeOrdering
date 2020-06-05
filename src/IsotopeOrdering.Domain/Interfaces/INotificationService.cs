using IsotopeOrdering.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface INotificationService {
        Task<List<Notification>> GetNotifications();
        Task<bool> SendNotification(string recipientName, string recipientEmail, string title, string message);
    }
}
