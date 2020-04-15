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
                if (requirement is RoleRequirement roleRequirement) {
                    await HandleRoleRequirement(context, roleRequirement);
                }
                if (requirement is InitiationRequirement initiationRequirement) {
                    await HandleInitiationRequirement(context, initiationRequirement);
                }
            }
        }

        private async Task HandleRoleRequirement(AuthorizationHandlerContext context, RoleRequirement requirement) {
            if (_roleService.UserRoles == null || !_roleService.UserRoles.Any()) {
                context.Fail();
            }
            else if (_roleService.UserRoles.Any(x => requirement.Roles.Contains(Enum.Parse<UserRole>(x)))) {
                context.Succeed(requirement);
            }
            await Task.CompletedTask;
        }

        private async Task HandleInitiationRequirement(AuthorizationHandlerContext context, InitiationRequirement requirement) {
            //if user's role is [customer] check their customer status
           if (_roleService.UserRoles.Any(x => requirement.UserRole == Enum.Parse<UserRole>(x))) {
                CustomerItemModel customer = await _customerManager.InitializeCustomerForCurrentUser();
                if (requirement.CustomerStatus == customer.Status) {
                    context.Succeed(requirement);
                }
                context.Fail();
            }
           //user's role does not apply to this requirement
            context.Succeed(requirement);
            await Task.CompletedTask;
        }

    }
}
