using System.Security.Claims;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Security {
    public interface IIsotopeOrderingAuthorizationService {
        Task<bool> AuthorizeAsync(string policyName);
        Task<bool> AuthorizeAsync(ClaimsPrincipal user, string policyName);
    }
}
