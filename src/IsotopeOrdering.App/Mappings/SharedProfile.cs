using AutoMapper;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities.Shared;

namespace IsotopeOrdering.App.Mappings {
    public class SharedProfile : Profile {
        public SharedProfile() {
            CreateMap<Address, AddressDetailModel>()
                .ReverseMap();
            CreateMap<Contact, ContactDetailModel>()
                .ReverseMap();
            CreateMap<Document, DocumentDetailModel>()
                .ReverseMap();
        }
    }
}
