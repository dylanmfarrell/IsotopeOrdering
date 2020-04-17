using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface INotificationService {
        Task SendNotification(string recipientName, string recipientEmail, string message);
    }
}
