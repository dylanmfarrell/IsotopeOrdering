using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using System.Collections.Generic;

namespace IsotopeOrdering.Infrastructure {
    public static class DataSeeding {
        public static IEnumerable<Form> GetFormSeedData() {
            yield return new Form() {
                Id = 1,
                Type = FormType.Initiation,
                Name = "Material Transfer Agreement"
            };
        }

        public static IEnumerable<Item> GetItemSeedData() {
            yield return new Item() {
                Id = 1,
                Name = "Cu-64",
                Target = "Ni-64",
                Reaction = "(p,n)",
                FinalComposition = "Copper chloride",
                SpecificActivity = "determined by TETA titration",
                QualityControlAnalysis = "germanium spectrum"
            };
            yield return new Item() {
                Id = 2,
                Name = "Y-86",
                Target = "Sr-86",
                Reaction = "(p,n)",
                FinalComposition = "Yttrium chloride",
                SpecificActivity = "determined by TETA titration",
                QualityControlAnalysis = "germanium spectrum"
            };
            yield return new Item() {
                Id = 3,
                Name = "Br-76",
                Target = "Se-76",
                Reaction = "(p,n)",
                FinalComposition = "Bromide",
                SpecificActivity = "N/A",
                QualityControlAnalysis = "germanium spectrum"
            };
            yield return new Item() {
                Id = 4,
                Name = "Br-77",
                Target = "Se-77",
                Reaction = "(p,n)",
                FinalComposition = "Bromide",
                SpecificActivity = "determined by TETA titration",
                QualityControlAnalysis = "germanium spectrum"
            };
            yield return new Item() {
                Id = 5,
                Name = "Zr-89",
                Target = "Y-89",
                Reaction = "(p,n)",
                FinalComposition = "Zirconium Oxalate",
                SpecificActivity = "determined by DFO titration",
                QualityControlAnalysis = "germanium spectrum"
            };
        }
    }
}
