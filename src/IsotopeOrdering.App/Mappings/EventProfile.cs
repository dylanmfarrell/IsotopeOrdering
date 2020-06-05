using AutoMapper;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class EventProfile : Profile {
        public EventProfile() {
            CreateMap<EntityEvent, EventItemModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.EventDateTime, opt => opt.MapFrom(x => x.EventDateTime));
        }
    }
}
