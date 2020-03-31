using IsotopeOrdering.Domain.Enums;
using System;

namespace IsotopeOrdering.Domain.Entities {
    public class EntityEvent {
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; } = DateTime.Now;
        public EntityEventType Type { get; set; }
        public int EntityId { get; set; }
        public string Description { get; set; } = null!;
    }
}
