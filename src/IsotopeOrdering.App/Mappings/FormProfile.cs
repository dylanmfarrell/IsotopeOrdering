﻿using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.Domain.Entities;
using System.Text.Json;

namespace IsotopeOrdering.App.Mappings {
    public class FormProfile : Profile {
        public FormProfile() {
            CreateMap<Form, FormDetailModel>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Type))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForMember(x => x.CustomerDetailFormId, opt => opt.Ignore())
                .ForMember(x => x.CustomerFormStatus, opt => opt.Ignore())
                .ForPath(x => x.InitiationModel, opt => opt.Ignore());

            CreateMap<CustomerForm, FormDetailModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.FormId))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Form.Type))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Form.Name))
                .ForMember(x => x.CustomerDetailFormId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.CustomerFormStatus, opt => opt.MapFrom(x => x.Status))
                .ForMember(x => x.InitiationModel, opt => opt.ConvertUsing<FormInitiationDetailModelFormatter, string?>(x => x.FormData));

            CreateMap<FormDetailModel, CustomerForm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.CustomerDetailFormId))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.FormId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.FormData, opt => opt.ConvertUsing<FormInitiationDetailModelToStringFormatter, FormInitiationDetailModel?>(x => x.InitiationModel))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.CustomerFormStatus))
                .ForAllOtherMembers(x=>x.Ignore());
        }
    }

    public class FormInitiationDetailModelFormatter : IValueConverter<string?, FormInitiationDetailModel> {
        public FormInitiationDetailModel Convert(string? sourceMember, ResolutionContext context) {
            if (string.IsNullOrEmpty(sourceMember)) {
                return new FormInitiationDetailModel();
            }
            return JsonSerializer.Deserialize<FormInitiationDetailModel>(sourceMember);
        }
    } 
    public class FormInitiationDetailModelToStringFormatter : IValueConverter<FormInitiationDetailModel?, string> {
        public string Convert(FormInitiationDetailModel? sourceMember, ResolutionContext context) {
            if (sourceMember == null) {
                return string.Empty;
            }
            return JsonSerializer.Serialize(sourceMember);
        }
    }
}