using IsotopeOrdering.Infrastructure.Options;
using Microsoft.Extensions.Options;
using MIR.Core.Domain;

namespace IsotopeOrdering.Infrastructure.Services {
    public class DevelopmentUserService : IUserService {
        private readonly IOptionsMonitor<DevelopmentOptions> _options;

        public DevelopmentUserService(IOptionsMonitor<DevelopmentOptions> options) {
            _options = options;
        }
        public IUser User => new DevelopmentUser(_options.CurrentValue);
    }
}
