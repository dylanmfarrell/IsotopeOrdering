using System;

namespace IsotopeOrdering.App.Models.Shared {
    public class DocumentDetailModel {
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public Guid UploadId { get; set; } = Guid.NewGuid();
    }
}
