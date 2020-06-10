using MIR.Core.Domain;
using System;

namespace IsotopeOrdering.Domain.Entities {
    public class Notification : ModelBase {
        public string RecipientName { get; set; } = null!;
        public string RecipientEmail { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public DateTime? SentDateTime { get; set; }
    }
}
