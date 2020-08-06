using System.Collections.Generic;
using System.Linq;

namespace IsotopeOrdering.App.Models.Dashboard {
    public class PendingTaskListModel {
        public List<PendingTaskModel> Tasks { get; set; } = new List<PendingTaskModel>();
        public bool HasPendingTasks => Tasks.Any();
        public void AddTask(int id, PendingTaskType type, string description) {
            Tasks.Add(new PendingTaskModel() { Id = id, Type = type, Description = description });
        }
    }
}
