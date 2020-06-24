using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface INotificationService {
        Task<List<NotificationConfiguration>> GetNotificationConfigurations();
        Task UpdateLastProcessedDate(int notificationConfigurationId);
        Task UpdateSentDates(List<int> notificationIds);
        Task<int> CreateNotifications(List<Notification> notifications);
        Task<List<Notification>> GetNotificationsForProcessing();
        Task<List<T>> GetConfigurationList<T>(NotificationTarget target);
        Task<NotificationConfiguration> GetExternalMtaNotificationConfiguration();
    }
}
