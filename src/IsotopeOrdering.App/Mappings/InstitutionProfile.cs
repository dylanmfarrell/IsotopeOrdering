using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class InstitutionProfile : Profile {
        public InstitutionProfile() {
            CreateMap<Institution, InstitutionDetailModel>()
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Address))
                .ForMember(x => x.FinancialContact, opt => opt.MapFrom(x => x.FinancialContact))
                .ForMember(x => x.SafetyContact, opt => opt.MapFrom(x => x.SafetyContact))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ReverseMap();
            CreateMap<Institution, InstitutionItemModel>();
        }
    }
}
