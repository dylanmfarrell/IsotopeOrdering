using IsotopeOrdering.Domain.Entities;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface INotificationManager {
        Task SendNotifications();
        Task ProcessNotificationConfigurations();
        Task ProcessNotificationConfiguration(NotificationConfiguration notification);
    }
}
