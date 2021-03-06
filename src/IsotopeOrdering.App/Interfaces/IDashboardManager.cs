﻿using IsotopeOrdering.App.Models.Dashboard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IDashboardManager {
        Task<PendingTaskListModel> GetPendingTasks();
    }
}
