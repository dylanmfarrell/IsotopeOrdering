using IsotopeOrdering.App.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Views.Shared.Components.PendingTaskList {
    public class PendingTaskList : ViewComponent {
        private readonly IDashboardManager _dashboardManager;

        public PendingTaskList(IDashboardManager dashboardManager) {
            _dashboardManager = dashboardManager;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            return View(await _dashboardManager.GetPendingTasks());
        }
    }
}
