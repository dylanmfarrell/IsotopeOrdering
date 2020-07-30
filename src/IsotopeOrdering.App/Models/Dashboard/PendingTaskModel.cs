namespace IsotopeOrdering.App.Models.Dashboard {
    public class PendingTaskModel {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public PendingTaskType Type { get; set; }
    }
}
