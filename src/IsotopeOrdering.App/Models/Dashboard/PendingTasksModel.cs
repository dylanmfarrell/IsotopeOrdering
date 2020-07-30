using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Dashboard {
    public class PendingTasksModel {
        public List<PendingTaskModel> Tasks { get; set; } = new List<PendingTaskModel>();
    }
}
