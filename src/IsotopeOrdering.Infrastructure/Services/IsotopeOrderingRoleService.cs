using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MIR.Core.Domain;
using MIR.Core.Mvc.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.Services {
    public class IsotopeOrderingRoleService : IRoleService {
        private readonly IAppManCoreService _service;
        private readonly IUserService _userService;
        private readonly IMemoryCache _cache;
        private readonly IOptions<RoleServiceOptions> _options;

        public IsotopeOrderingRoleService(IAppManCoreService appmanService, IUserService userService, IMemoryCache cache, IOptions<RoleServiceOptions> options) {
            _service = appmanService;
            _userService = userService;
            _cache = cache;
            _options = options;
        }
        public IEnumerable<string> UserRoles => GetUserRoles().Result;

        private async Task<IEnumerable<string>> GetUserRoles() {
            string key = $"{_options.Value.Token}|{_userService.User.Email}";
            if (_cache.TryGetValue(key, out IEnumerable<string> roles)) {
                return roles;
            }
            roles = await _service.GetUserRolesByEmail(_userService.User.Email, _options.Value.Token, _options.Value.DefaultRole);
            return _cache.Set(key, roles, new TimeSpan(0, 10, 0));
        }
    }

    public static class IsotopeOrderingRoleServiceExtensions {
        public static IServiceCollection AddIsotopeOrderingRoleService(this IServiceCollection services, Action<RoleServiceOptions> options) {
            services.Configure(options);
            services.AddSingleton<IRoleService, IsotopeOrderingRoleService>();
            return services;
        }
    }
}
