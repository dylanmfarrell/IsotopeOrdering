using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace IsotopeOrdering.App.Security {
    public class RoleRequirement : IAuthorizationRequirement {
        public readonly UserRole[] Roles;

        public RoleRequirement(params UserRole[] roles) {
            Roles = roles;
        }
    }
}
