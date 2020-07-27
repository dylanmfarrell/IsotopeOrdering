using IsotopeOrdering.Domain.Enums;

namespace IsotopeOrdering.App.Models.Items {
    public class NotificationConfigurationItemModel {
        public int Id { get; set; }
        public string? Title { get; set; }
        public NotificationTarget Target { get; set; }
        public string DisplayName => $"{Target} - {Title}";
    }
}
