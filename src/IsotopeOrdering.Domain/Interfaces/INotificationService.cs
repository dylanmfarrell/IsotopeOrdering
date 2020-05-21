using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface INotificationService {
        Task<bool> SendNotification(string recipientName, string recipientEmail, string title, string message);
    }
}
