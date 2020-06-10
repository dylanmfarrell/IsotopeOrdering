using IsotopeOrdering.Domain.Entities;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface INotificationManager {
        /// <summary>
        /// Sends all notifications where the sent date is null.
        /// </summary>
        /// <returns>The number of notifications sent</returns>
        Task<int> SendNotifications();
        /// <summary>
        /// Creates notifications for all notification configurations.
        /// </summary>
        /// <returns>The number of notifications created</returns>
        Task<int> ProcessNotificationConfigurations();
        /// <summary>
        /// Creates notifications for notification configuration for all target events past last processed date.
        /// </summary>
        /// <param name="notification"></param>
        /// <returns>The number of notifications created</returns>
        Task<int> ProcessNotificationConfiguration(NotificationConfiguration notification);
    }
}
