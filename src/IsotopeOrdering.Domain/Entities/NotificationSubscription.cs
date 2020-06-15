using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class NotificationSubscription : ModelBase {
        public NotificationConfiguration NotificationConfiguration { get; set; } = null!;
        public int NotificationConfigurationId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int CustomerId { get; set; }
    }
}
