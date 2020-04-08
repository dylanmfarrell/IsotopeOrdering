using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace IsotopeOrdering.App.Security {
    public static class PolicyConfiguration {
        public static void AddPolicies(this AuthorizationOptions options) {
            options.AddPolicy(Policies.AdminPolicy, policy => policy.Requirements.Add(new RoleRequirement(UserRole.Admin)));
            options.AddPolicy(Policies.ReviewerPolicy, policy => policy.Requirements.Add(new RoleRequirement(UserRole.Admin, UserRole.Reviewer)));
            options.AddPolicy(Policies.CustomerPolicy, policy => policy.AddRequirements(new RoleRequirement(UserRole.Customer), new InitiationRequirement(CustomerStatus.Initiated)));
        }
    }
}
