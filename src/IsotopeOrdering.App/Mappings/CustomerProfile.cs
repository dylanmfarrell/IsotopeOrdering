using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Notifications;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.App.Mappings {
    public class CustomerProfile : Profile {
        public CustomerProfile() {
            CreateMap<Customer, CustomerItemModel>()
                .ForMember(x => x.Contact, opt => opt.MapFrom(x => x.Contact))
                .ReverseMap();
            CreateMap<Customer, CustomerDetailModel>()
                .ForMember(x => x.Contact, opt => opt.MapFrom(x => x.Contact))
                .ReverseMap();

            CreateMap<CustomerAddress, CustomerAddressDetailModel>()
                .ReverseMap();
            CreateMap<CustomerAddress, OrderAddressDetailModel>();
            CreateMap<CustomerDocument, CustomerDocumentDetailModel>()
                .ReverseMap();
            CreateMap<CustomerInstitution, CustomerInstitutionDetailModel>()
                .ReverseMap();
            CreateMap<Customer, CustomerSearchResult>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(x => x.Label, opt => opt.MapFrom(src => src.Contact.FirstName + " " + src.Contact.LastName));
            CreateMap<IUser, Customer>()
                .ForPath(x => x.UserId, opt => opt.MapFrom(src => src.EducationId))
                .ForPath(x => x.Contact.Email, opt => opt.MapFrom(src => src.Email))
                .ForPath(x => x.Contact.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(x => x.Contact.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForAllOtherMembers(x => x.Ignore());
            CreateMap<CustomerInstitution, CustomerAddressDetailModel>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => AddressType.Default))
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Institution.Address));

            CreateMap<Customer, RecipientDto>()
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(x => x.Contact.Email))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Contact.FirstName + " " + x.Contact.LastName));
        }
    }
}
