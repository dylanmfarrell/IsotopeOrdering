using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class DevelopmentAppManCoreService : IAppManCoreService {
        public async Task<string> GetResponseJson(string url) {
            return await Task.FromResult(string.Empty);
        }

        public async Task<IEnumerable<string>> GetUserRoles(string wustlEduId, string applicationToken, string defaultRole) {
            return await Task.FromResult(new string[0]);
        }

        public async Task<IEnumerable<string>> GetUserRolesByEmail(string emailAddress, string applicationToken, string defaultRole) {
            return await Task.FromResult(new string[0]);
        }
    }
}
