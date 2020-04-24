using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;

namespace IsotopeOrdering.Infrastructure.Services {
    public class DevelopmentRoleService : IRoleService {
        public IEnumerable<string> UserRoles => new string[] { UserRole.Admin.ToString() };
    }
}
