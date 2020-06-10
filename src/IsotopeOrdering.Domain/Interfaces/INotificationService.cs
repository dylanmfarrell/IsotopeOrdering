using IsotopeOrdering.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface INotificationService {
        Task<List<NotificationConfiguration>> GetNotificationConfigurations();
        Task UpdateLastProcessedDate(int notificationConfigurationId);
        Task UpdateSentDates(List<int> notificationIds);
        Task CreateNotifications(List<Notification> notifications);
        Task<List<Notification>> GetNotificationsForProcessing();
    }
}
