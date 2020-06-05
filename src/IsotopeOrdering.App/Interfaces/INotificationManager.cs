using IsotopeOrdering.Domain.Entities;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface INotificationManager {
        Task ProcessNotifications();
        Task ProcessNotification(Notification notification);
    }
}
