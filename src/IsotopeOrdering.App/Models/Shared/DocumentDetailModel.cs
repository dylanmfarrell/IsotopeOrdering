using System;

namespace IsotopeOrdering.App.Models.Shared {
    public class DocumentDetailModel {
        public string? Name { get; set; } = string.Empty;
        public string? Details { get; set; } = string.Empty;
        public Guid UploadId { get; set; } = Guid.NewGuid();
    }
}
