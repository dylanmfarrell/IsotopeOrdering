using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Security {
    public class RolePolicyProvider : IAuthorizationPolicyProvider {
        private const string POLICY_PREFIX = "RolePolicy";
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }
        public RolePolicyProvider(IOptions<AuthorizationOptions> options) {
            // ASP.NET Core only uses one authorization policy provider, so if the custom implementation
            // doesn't handle all policies (including default policies, etc.) it should fall back to an
            // alternate provider.
            //
            // In this sample, a default authorization policy provider (constructed with options from the 
            // dependency injection container) is used if this custom provider isn't able to handle a given
            // policy name.
            //
            // If a custom policy provider is able to handle all expected policy names then, of course, this
            // fallback pattern is unnecessary.
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetFallbackPolicyAsync();

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName) {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
                Enum.TryParse(policyName.Substring(POLICY_PREFIX.Length), out UserRole role)) {
                AuthorizationPolicyBuilder policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new RoleRequirement(role));
                return Task.FromResult(policy.Build());
            }
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
