using AutoMapper;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities.Shared;

namespace IsotopeOrdering.App.Mappings {
    public class SharedProfile : Profile {
        public SharedProfile() {
            CreateMap<Address, AddressDetailModel>();
            CreateMap<Contact, ContactDetailModel>();
            CreateMap<Document, DocumentDetailModel>();
        }
    }
}
