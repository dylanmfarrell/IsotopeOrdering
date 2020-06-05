using System;

namespace IsotopeOrdering.App.Models.Items {
    public class EventItemModel {
        public DateTime EventDateTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Display => $"{EventDateTime} - {Description}";
    }
}
