using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class OrderProfile : Profile {
        public OrderProfile() {
            CreateMap<Item, OrderItemDetailModel>()
              .ForMember(x => x.Item, opt => opt.MapFrom(x => x))
              .ForMember(x => x.ItemConfigurations, opt => opt.MapFrom(x => x.ItemConfigurations))
              .ForMember(x => x.SpecialInstructions, opt => opt.Ignore())
              .ForMember(x => x.Quantity, opt => opt.Ignore());

            CreateMap<OrderItemDetailModel, OrderItem>()
                .ForMember(x => x.ItemConfiguration, opt => opt.Ignore())
                .ForMember(x => x.ItemConfigurationId, opt => opt.MapFrom(x=>x.ItemConfigurationId))
                .ForMember(x => x.OrderId, opt => opt.Ignore())
                .ForMember(x => x.Order, opt => opt.Ignore())
                .ForMember(x => x.Quantity, opt => opt.MapFrom(x => x.Quantity))
                .ForMember(x => x.SpecialInstructions, opt => opt.MapFrom(x => x.SpecialInstructions));

            CreateMap<OrderDetailModel, Order>()
                .ForMember(x => x.Billing, opt => opt.MapFrom(x => x.BillingAddress))
                .ForMember(x => x.Shipping, opt => opt.MapFrom(x => x.ShippingAddress))
                .ForMember(x => x.Items, opt => opt.MapFrom(x => x.Cart))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForMember(x => x.InstitutionId, opt => opt.MapFrom(x => x.Institution.Id))
                .ForMember(x => x.Institution, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status))
                .ForMember(x => x.FedExNumber, opt => opt.MapFrom(x => x.FedExNumber))
                .ForMember(x => x.Notes, opt => opt.MapFrom(x => x.Notes));
        }
    }
}
