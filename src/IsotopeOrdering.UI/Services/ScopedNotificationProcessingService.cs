using IsotopeOrdering.App.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Services {
    public class ScopedNotificationProcessingService : IScopedNotificationProcessingService {
        private int executionCount = 0;
        private readonly ILogger _logger;
        private readonly INotificationManager _notificationManager;
        private int _taskIntervalSeconds = 30;

        public ScopedNotificationProcessingService(ILogger<ScopedNotificationProcessingService> logger, INotificationManager notificationManager) {
            _logger = logger;
            _notificationManager = notificationManager;
        }

        public async Task DoWork(CancellationToken stoppingToken) {
            while (!stoppingToken.IsCancellationRequested) {
                executionCount++;

                _logger.LogInformation("Processing events/notifications");
                await _notificationManager.ProcessNotificationConfigurations();
                _logger.LogInformation("Processing events/notifications complete");

                _logger.LogInformation("Sending notifications");
                await _notificationManager.SendNotifications();
                _logger.LogInformation("Sending notifications complete");

                _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", executionCount);
                await Task.Delay(_taskIntervalSeconds * 1000, stoppingToken);
            }
        }
    }
}
