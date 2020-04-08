using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using MIR.Core.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Security {
    public class PolicyHandler : IAuthorizationHandler {
        private readonly IRoleService _roleService;
        private readonly ICustomerManager _customerManager;

        public PolicyHandler(IRoleService roleService, ICustomerManager customerManager) {
            _roleService = roleService;
            _customerManager = customerManager;
        }

        public async Task HandleAsync(AuthorizationHandlerContext context) {
            var pendingRequirements = context.PendingRequirements.ToList();
            foreach (var requirement in pendingRequirements) {
                if (requirement is RoleRequirement) {
                    if (_roleService.UserRoles == null || !_roleService.UserRoles.Any()) {
                        context.Fail();
                    }
                    else if (_roleService.UserRoles.Any(x => ((RoleRequirement)requirement).Roles.Contains(Enum.Parse<UserRole>(x)))) {
                        context.Succeed(requirement);
                    }
                }
                if (requirement is InitiationRequirement) {
                    CustomerItemModel customer = await _customerManager.InitializeCustomerForCurrentUser();
                    if (((InitiationRequirement)requirement).CustomerStatus == customer.Status) {
                        context.Succeed(requirement);
                    }
                    else {
                        context.Fail();
                    }
                }
                else {
                    throw new NotImplementedException($"The requirement {requirement.GetType().Name }has not been implemented");
                }
            }
        }

    }
}
