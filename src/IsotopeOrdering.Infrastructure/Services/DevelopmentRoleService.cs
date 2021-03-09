using IsotopeOrdering.Infrastructure.Options;
using Microsoft.Extensions.Options;
using MIR.Core.Domain;
using System.Collections.Generic;

namespace IsotopeOrdering.Infrastructure.Services {
    public class DevelopmentRoleService : IRoleService {
        private readonly IOptionsMonitor<DevelopmentOptions> _options;

        public DevelopmentRoleService(IOptionsMonitor<DevelopmentOptions> options) {
            _options = options;
        }
        public IEnumerable<string> UserRoles => new string[] { _options.CurrentValue.DevelopmentRole.ToString() }; 
    }
}
