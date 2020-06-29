using Microsoft.AspNetCore.Authorization;

namespace IsotopeOrdering.App.Security {
    public class AuthorizationRequirement : IAuthorizationRequirement {
        public bool RequiresAuthorization;
        public AuthorizationRequirement(bool requiresAuthorization) {
            RequiresAuthorization = requiresAuthorization;
        }
    }
}
