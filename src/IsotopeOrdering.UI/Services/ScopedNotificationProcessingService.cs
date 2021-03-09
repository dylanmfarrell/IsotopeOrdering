using IsotopeOrdering.App.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Services {
    public class ScopedNotificationProcessingService : IScopedNotificationProcessingService {
        private readonly ILogger _logger;
        private readonly INotificationManager _notificationManager;
        private readonly int _taskIntervalSeconds = 30;

        public ScopedNotificationProcessingService(ILogger<ScopedNotificationProcessingService> logger, INotificationManager notificationManager) {
            _logger = logger;
            _notificationManager = notificationManager;
        }

        public async Task DoWork(CancellationToken stoppingToken) {
            while (!stoppingToken.IsCancellationRequested) {

                int notificationsProcessed = await _notificationManager.ProcessNotificationConfigurations();

                int notificationSent = await _notificationManager.SendNotifications();

                _logger.LogInformation("Processed {notificationsProcessed} events/notifications.Sent {emailsSent} notifications.", notificationsProcessed, notificationSent);

                await Task.Delay(_taskIntervalSeconds * 1000, stoppingToken);
            } 
        }
    }
}
