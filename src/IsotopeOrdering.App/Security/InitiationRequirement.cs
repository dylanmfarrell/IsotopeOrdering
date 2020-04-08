using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace IsotopeOrdering.App.Security {
    public class InitiationRequirement : IAuthorizationRequirement {
        public readonly CustomerStatus CustomerStatus;

        public InitiationRequirement(CustomerStatus customerStatus) {
            CustomerStatus = customerStatus;
        }
    }
}
