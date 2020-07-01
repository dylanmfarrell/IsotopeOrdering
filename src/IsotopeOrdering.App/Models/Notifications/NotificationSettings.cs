using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Notifications {
    public class NotificationSettings {
        public string BaseUrl { get; set; } = null!;
        public List<NotificationAdmin> Admins { get; set; } = new List<NotificationAdmin>();
    }

    public class NotificationAdmin {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
