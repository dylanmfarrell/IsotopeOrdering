using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.Infrastructure {
    public static class DataSeeding {
        private const string _systemUser = "SYSTEM";
        private static readonly DateTime _now = DateTime.Now;

        public static IEnumerable<Form> GetFormSeedData() {
            yield return new Form() {
                Id = 1,
                Type = FormType.Initiation,
                Name = "Material Transfer Agreement",
                CreatedBy = _systemUser,
                UpdatedBy = _systemUser,
                CreatedDate = _now,
                UpdatedDate = _now
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
                QualityControlAnalysis = "germanium spectrum",
                CreatedBy = _systemUser,
                UpdatedBy = _systemUser,
                CreatedDate = _now,
                UpdatedDate = _now
            };
            yield return new Item() {
                Id = 2,
                Name = "Y-86",
                Target = "Sr-86",
                Reaction = "(p,n)",
                FinalComposition = "Yttrium chloride",
                SpecificActivity = "N/A",
                QualityControlAnalysis = "germanium spectrum",
                CreatedBy = _systemUser,
                UpdatedBy = _systemUser,
                CreatedDate = _now,
                UpdatedDate = _now
            };
            yield return new Item() {
                Id = 3,
                Name = "Br-76",
                Target = "Se-76",
                Reaction = "(p,n)",
                FinalComposition = "Bromide",
                SpecificActivity = "N/A",
                QualityControlAnalysis = "germanium spectrum",
                CreatedBy = _systemUser,
                UpdatedBy = _systemUser,
                CreatedDate = _now,
                UpdatedDate = _now
            };
            yield return new Item() {
                Id = 4,
                Name = "Br-77",
                Target = "Se-77",
                Reaction = "(p,n)",
                FinalComposition = "Bromide",
                SpecificActivity = "N/A",
                QualityControlAnalysis = "germanium spectrum",
                CreatedBy = _systemUser,
                UpdatedBy = _systemUser,
                CreatedDate = _now,
                UpdatedDate = _now
            };
            yield return new Item() {
                Id = 5,
                Name = "Zr-89",
                Target = "Y-89",
                Reaction = "(p,n)",
                FinalComposition = "Zirconium Oxalate",
                SpecificActivity = "determined by DFO titration",
                QualityControlAnalysis = "germanium spectrum",
                CreatedBy = _systemUser,
                UpdatedBy = _systemUser,
                CreatedDate = _now,
                UpdatedDate = _now
            };
        }

        public static IEnumerable<ItemConfiguration> GetItemConfigurationSeedData() {
            foreach (Item item in GetItemSeedData()) {
                yield return new ItemConfiguration() {
                    Id = item.Id,
                    ItemId = item.Id,
                    CustomerId = null,
                    MinimumAmount = 0m,
                    MaximumAmount = 100m,
                    Price = 1000,
                    CreatedBy = _systemUser,
                    UpdatedBy = _systemUser,
                    CreatedDate = _now,
                    UpdatedDate = _now
                };
            }

        }
    }
}
