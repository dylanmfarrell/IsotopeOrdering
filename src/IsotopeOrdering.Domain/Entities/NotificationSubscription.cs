using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class NotificationSubscription : ModelBase {
        public Notification Notification { get; set; } = null!;
        public int NotificationId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int CustomerId { get; set; }
    }
}
