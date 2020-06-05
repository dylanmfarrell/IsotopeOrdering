using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class NotificationService : INotificationService {
        private readonly IsotopeOrderingDbContext _context;

        public NotificationService(IsotopeOrderingDbContext context) {
            _context = context;
        }
        public async Task<List<Notification>> GetNotifications() {
            return await _context.Notifications
                .Include(x => x.Subscriptions)
                    .ThenInclude(x => x.Customer)
                .ToListAsync();
        }

        public async Task<bool> SendNotification(string recipientName, string recipientEmail, string title, string message) {
            return await Task.FromResult(true);
        }
    }
}
