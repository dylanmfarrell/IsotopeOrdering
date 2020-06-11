using IsotopeOrdering.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IEmailService {
        Task<bool> Send(Notification notification);
        Task<Dictionary<int,bool>> Send(List<Notification> notifications);
    }
}
