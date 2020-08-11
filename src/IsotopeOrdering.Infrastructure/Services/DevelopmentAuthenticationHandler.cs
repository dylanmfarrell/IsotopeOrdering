using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class DevelopmentAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions> {
        public DevelopmentAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock) {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "username", "devauth"));
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));
            return await Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
        }
    }
}
