using System.Threading;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Services {
    public interface IScopedNotificationProcessingService {
        Task DoWork(CancellationToken stoppingToken);
    }
}
 