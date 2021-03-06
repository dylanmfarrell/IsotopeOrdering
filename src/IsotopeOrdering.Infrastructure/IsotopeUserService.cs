﻿using IdentityModel;
using Microsoft.AspNetCore.Http;
using MIR.Core.Domain;
using System.Linq;
using System.Security.Claims;

namespace IsotopeOrdering.Infrastructure {
    public class IsotopeUserService : IUserService {
        private readonly IHttpContextAccessor _accessor;

        public IsotopeUserService(IHttpContextAccessor accessor) {
            _accessor = accessor;
        }

        public IUser User => new IsotopeUser(_accessor.HttpContext.User);
    }

    public class IsotopeUser : IUser {
        private readonly ClaimsPrincipal _claimsPrincipal;

        public IsotopeUser(ClaimsPrincipal claimsPrincipal) {
            _claimsPrincipal = claimsPrincipal;
        }

        public ClaimsPrincipal ClaimsPrincipal => _claimsPrincipal;

        public string UserName => GetClaimValue(JwtClaimTypes.PreferredUserName);

        public string FirstName => GetClaimValue(JwtClaimTypes.Name);

        public string LastName => string.Empty;

        public string EducationId => GetClaimValue(JwtClaimTypes.PreferredUserName);

        public string PhoneNumber => GetClaimValue(JwtClaimTypes.PhoneNumber);

        public string Email => GetClaimValue(JwtClaimTypes.Email);

        private string GetClaimValue(string jwtType) {
            Claim? claim = _claimsPrincipal.Claims.FirstOrDefault(x => x.Type == jwtType);
            return claim?.Value ?? string.Empty;
        }
    }

    public class SystemUser : IUser {
        public ClaimsPrincipal ClaimsPrincipal => throw new System.NotImplementedException();

        public string UserName => "SYSTEM";

        public string FirstName => "SYSTEM";

        public string LastName => "SYSTEM";

        public string EducationId => throw new System.NotImplementedException();

        public string PhoneNumber => throw new System.NotImplementedException();

        public string Email => throw new System.NotImplementedException();
    }


}
