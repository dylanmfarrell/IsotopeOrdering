using System;

namespace IsotopeOrdering.Domain.Entities.Shared {
    public class Document {
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public Guid UploadId { get; set; }
    }
}
