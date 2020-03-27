using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class FormProfile : Profile {
        public FormProfile() {
            CreateMap<Form, FormDetailModel>()
                .ForPath(x => x.InitiationModel, opt => opt.Ignore());
        }
    }
}
