using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.Domain.Entities {
    public class NotificationConfiguration : ModelBase {
        public string Title { get; set; } = null!;
        public NotificationTarget Target { get; set; }
        public string EventTrigger { get; set; } = null!;
        public string TemplatePath { get; set; } = null!;
        public DateTime? LastProcessed { get; set; }
        public List<NotificationSubscription> Subscriptions { get; set; } = new List<NotificationSubscription>();
    }
}
