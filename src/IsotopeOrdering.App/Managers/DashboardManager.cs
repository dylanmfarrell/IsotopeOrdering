using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Dashboard;
using IsotopeOrdering.App.Security;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class DashboardManager : IDashboardManager {
        private readonly IIsotopeOrderingAuthorizationService _authorization;

        public DashboardManager(IIsotopeOrderingAuthorizationService authorization) {
            _authorization = authorization;
        }

        public async Task<PendingTasksModel> GetPendingTask() {
            bool isReviewer = await _authorization.AuthorizeAsync(Policies.ReviewerPolicy);
            PendingTasksModel model = new PendingTasksModel();
            return model;
        }
    }
}
