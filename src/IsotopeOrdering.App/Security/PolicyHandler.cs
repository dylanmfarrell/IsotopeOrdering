using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using MIR.Core.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Security {
    public class PolicyHandler : IAuthorizationHandler {
        private readonly IRoleService _roleService;
        private readonly ICustomerService _customerService;

        public PolicyHandler(IRoleService roleService, ICustomerService customerService) {
            _roleService = roleService;
            _customerService = customerService;
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
                if (requirement is AuthorizationRequirement authorizationRequirement) {
                    await HandleAuthorizationRequirement(context, authorizationRequirement);
                }
            }
        }

        private async Task HandleAuthorizationRequirement(AuthorizationHandlerContext context, AuthorizationRequirement requirement) {
            if (requirement.RequiresAuthorization) {
                if (context.User.Identity.IsAuthenticated) {
                    context.Succeed(requirement);
                }
                else {
                    context.Fail();
                }
            }
            else {
                context.Succeed(requirement);
            }
            await Task.CompletedTask;
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
                CustomerItemModel? customer = await _customerService.GetCurrentCustomer<CustomerItemModel>();
                if (customer != null && requirement.CustomerStatus == customer.Status) {
                    context.Succeed(requirement);
                }
                else {
                    context.Fail();
                }
            }
            else {
                //user's role does not apply to this requirement
                context.Succeed(requirement);
            }
            await Task.CompletedTask;
        }

    }
}
