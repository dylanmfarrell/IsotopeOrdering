using IsotopeOrdering.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IEmailService {
        Task<bool> SendNotification(Notification notification);
        Task<Dictionary<int,bool>> SendNotifications(List<Notification> notifications);
    }
}
