using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class NotificationService : INotificationService {
        private readonly IMapper _mapper;
        private readonly IsotopeOrderingDbContext _context;

        public NotificationService(IMapper mapper, IsotopeOrderingDbContext context) {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> CreateNotifications(List<Notification> notifications) {
            _context.Notifications.AddRange(notifications);
            return await _context.SaveChangesAsync("SYSTEM");
        }

        public async Task<List<T>> GetConfigurationList<T>(NotificationTarget target) {
            return await _mapper.ProjectTo<T>(_context.NotificationConfigurations.Where(x => x.Target == target)).ToListAsync();
        }

        public async Task<List<NotificationConfiguration>> GetNotificationConfigurations() {
            return await _context.NotificationConfigurations
                          .Include(x => x.Subscriptions)
                              .ThenInclude(x => x.Customer)
                          .ToListAsync();
        }

        public async Task<List<Notification>> GetNotificationsForProcessing() {
            return await _context.Notifications.Where(x => !x.SentDateTime.HasValue).ToListAsync();
        }

        public async Task UpdateLastProcessedDate(int notificationConfigurationId) {
            NotificationConfiguration notificationConfiguration = await _context.NotificationConfigurations.FindAsync(notificationConfigurationId);
            notificationConfiguration.LastProcessed = DateTime.Now;
            await _context.SaveChangesAsync("SYSTEM");
        }

        public async Task UpdateSentDates(List<int> notificationIds) {
            List<Notification> notifications = await _context.Notifications.Where(x => notificationIds.Contains(x.Id)).ToListAsync();
            notifications.ForEach(x => x.SentDateTime = DateTime.Now);
            await _context.SaveChangesAsync("SYSTEM");
        }
    }
}
