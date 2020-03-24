using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.Domain.Entities {
    public class Form : ModelBase {
        public FormType Type { get; set; }
        public string Name { get; set; } = null!;
    }
}
