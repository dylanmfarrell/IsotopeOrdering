using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class DevelopmentEmailService : IEmailService {
        public async Task<bool> Send(Notification notification) {
            return await Task.FromResult(true);
        }

        public async Task<Dictionary<int, bool>> Send(List<Notification> notifications) {
            return await Task.FromResult(new Dictionary<int, bool>()); 
        }
    }
}
