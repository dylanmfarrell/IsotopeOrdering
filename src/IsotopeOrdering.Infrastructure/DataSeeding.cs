using IsotopeOrdering.Domain;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsotopeOrdering.Infrastructure {
    internal static class DataSeeding {
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

        public static IEnumerable<NotificationConfiguration> GetNotificationConfigurationSeedData() {
            Dictionary<string, string> events = Events.GetEvents();
            int id = 1;
            for (int i = 0; i < events.Count; i++) {
                KeyValuePair<string, string> eventPair = events.ElementAt(i);
                yield return new NotificationConfiguration() {
                    Id = id,
                    EventTrigger = eventPair.Value,
                    LastProcessed = null,
                    Title = eventPair.Value,
                    TemplatePath = eventPair.Key,
                    IsDeleted = false,
                    Target = NotificationTarget.Admin,
                    CreatedBy = _systemUser,
                    UpdatedBy = _systemUser,
                    CreatedDate = _now,
                    UpdatedDate = _now
                };
                id++;
                yield return new NotificationConfiguration() {
                    Id = id,
                    EventTrigger = eventPair.Value,
                    LastProcessed = null,
                    Title = eventPair.Value,
                    TemplatePath = eventPair.Key,
                    IsDeleted = false,
                    Target = NotificationTarget.Customer,
                    CreatedBy = _systemUser,
                    UpdatedBy = _systemUser,
                    CreatedDate = _now,
                    UpdatedDate = _now
                };
                id++;
            }
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
    }
}
