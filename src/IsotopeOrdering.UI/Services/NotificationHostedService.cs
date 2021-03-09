using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Services {
    public class NotificationBackgroundService : BackgroundService {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<NotificationBackgroundService> _logger;

        public NotificationBackgroundService(IServiceProvider serviceProvider, ILogger<NotificationBackgroundService> logger) {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            _logger.LogInformation("Notification service running");
            await DoWork(stoppingToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken) {
            _logger.LogInformation("Notification service is stopping");
            await Task.CompletedTask; 
        }

        private async Task DoWork(CancellationToken stoppingToken) {
            using var scope = _serviceProvider.CreateScope();
            var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IScopedNotificationProcessingService>();
            await scopedProcessingService.DoWork(stoppingToken);
        }
    }
}
