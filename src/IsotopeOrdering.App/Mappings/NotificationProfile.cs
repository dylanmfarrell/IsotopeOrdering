using AutoMapper;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class NotificationProfile : Profile {
        public NotificationProfile() {
            CreateMap<NotificationConfiguration, NotificationConfigurationItemModel>();
        }
    }
}
