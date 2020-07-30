using System;

namespace IsotopeOrdering.Domain.Entities.Shared {
    public class Document {
        public string? Name { get; set; } = string.Empty;
        public string? Details { get; set; } = string.Empty;
        public Guid UploadId { get; set; }
    }
}
