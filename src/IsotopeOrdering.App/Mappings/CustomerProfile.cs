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
                .ReverseMap();

            CreateMap<Customer, CustomerDetailModel>()
                .ForPath(x => x.SubscriptionConfiguration.Subscriptions, opt => opt.MapFrom(x => x.Subscriptions))
                .ForMember(x => x.Subscriptions, opt => opt.MapFrom(x => x.Subscriptions));

            CreateMap<CustomerDetailModel, Customer>()
                .ForMember(x => x.Forms, opt => opt.Ignore())
                .ForMember(x => x.Subscriptions, opt => opt.MapFrom(x => x.SubscriptionConfiguration.Subscriptions))
                .ForMember(x => x.ParentCustomer, opt => opt.Ignore());

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

            CreateMap<CustomerSubscriptionDetailModel, NotificationSubscription>()
                .ForMember(x => x.NotificationConfigurationId, opt => opt.MapFrom(x => x.Configuration.Id))
                .ForMember(x => x.IsDeleted, opt => opt.MapFrom(x => x.IsDeleted))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.CustomerId))
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.NotificationConfiguration, opt => opt.Ignore());

            CreateMap<NotificationSubscription, CustomerSubscriptionDetailModel>()
               .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
               .ForMember(x => x.IsDeleted, opt => opt.MapFrom(x => x.IsDeleted))
               .ForMember(x => x.IsSelected, opt => opt.MapFrom(x => !x.IsDeleted))
               .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.CustomerId))
               .ForMember(x => x.Configuration, opt => opt.MapFrom(x => x.NotificationConfiguration));

        }
    }
}
