using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace IsotopeOrdering.App.Security {
    public class InitiationRequirement : IAuthorizationRequirement {
        public readonly CustomerStatus CustomerStatus;
        public readonly UserRole UserRole;

        public InitiationRequirement(UserRole userRole, CustomerStatus customerStatus) {
            UserRole = userRole;
            CustomerStatus = customerStatus;
        }
    }
}
