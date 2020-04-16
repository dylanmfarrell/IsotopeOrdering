using Microsoft.AspNetCore.Authorization;
using MIR.Core.Domain;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Security {
    public class IsotopeOrderingAuthorizationService : IIsotopeOrderingAuthorizationService {
        private readonly IAuthorizationService _service;
        private readonly IUserService _userService;

        public IsotopeOrderingAuthorizationService(IAuthorizationService service, IUserService userService) {
            _service = service;
            _userService = userService;
        }

        public async Task<bool> AuthorizeAsync(string policy) {
            return await AuthorizeAsync(_userService.User.ClaimsPrincipal, policy);
        }

        public async Task<bool> AuthorizeAsync(ClaimsPrincipal user, string policyName) {
            AuthorizationResult authorizationResult = await _service.AuthorizeAsync(user, policyName);
            return authorizationResult.Succeeded;
        }
    }
}
