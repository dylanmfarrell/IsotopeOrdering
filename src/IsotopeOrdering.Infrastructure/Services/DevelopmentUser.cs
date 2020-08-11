using IsotopeOrdering.Infrastructure.Options;
using MIR.Core.Domain;
using System.Security.Claims;

namespace IsotopeOrdering.Infrastructure.Services {
    public class DevelopmentUser : IUser {
        private readonly DevelopmentOptions _options;

        public DevelopmentUser(DevelopmentOptions options) {
            _options = options;
        }

        public ClaimsPrincipal ClaimsPrincipal => new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, "username", "devauth") }));

        public string UserName => _options.UserName;

        public string FirstName => _options.FirstName;

        public string LastName => _options.LastName;

        public string EducationId => _options.EducationId;

        public string PhoneNumber => _options.PhoneNumber;

        public string Email => _options.Email;
    }
}
