﻿using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;
using MIR.Core.Domain;

namespace IsotopeOrdering.App.Mappings {
    public class CustomerProfile : Profile {
        public CustomerProfile() {
            CreateMap<Customer, CustomerItemModel>()
                .ReverseMap();
            CreateMap<Customer, CustomerDetailModel>()
                .ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressDetailModel>()
                .ReverseMap();
            CreateMap<CustomerDocument, CustomerDocumentDetailModel>()
                .ReverseMap();
            CreateMap<CustomerInstitution, CustomerInstitutionDetailModel>()
                .ReverseMap();
            CreateMap<IUser, Customer>()
                .ForPath(x => x.Contact.Email, opt => opt.MapFrom(src => src.Email))
                .ForPath(x => x.Contact.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(x => x.Contact.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
