using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class InstitutionProfile : Profile {
        public InstitutionProfile() {
            CreateMap<Institution, InstitutionDetailModel>()
                .ReverseMap();
            CreateMap<Institution, InstitutionItemModel>();
        }
    }
}
