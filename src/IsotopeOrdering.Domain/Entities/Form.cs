using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace IsotopeOrdering.Domain.Entities {
    public class Form : ModelBase {
        [Required]
        public FormType Type { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string ViewPath { get; set; } = null!;
    }
}
