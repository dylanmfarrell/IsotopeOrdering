using IsotopeOrdering.Domain.Enums;
using System;

namespace IsotopeOrdering.Domain.Entities {
    public class EntityEvent {
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public EntityEventType Type { get; set; }
        public EntityEventAction Action { get; set; }
        public string CurrentState { get; set; } = null!;
        public string? NewState { get; set; }
    }
}
