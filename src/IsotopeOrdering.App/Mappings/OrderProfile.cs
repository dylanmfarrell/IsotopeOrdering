using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using System.Linq;

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
                .ForMember(x => x.ItemConfigurationId, opt => opt.MapFrom<OrderItemConfigurationResolver>())
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

        public class OrderItemConfigurationResolver : IValueResolver<OrderItemDetailModel, OrderItem, int> {
            public int Resolve(OrderItemDetailModel source, OrderItem destination, int destMember, ResolutionContext context) {
                ItemConfigurationDetailModel model = source.ItemConfigurations.FirstOrDefault(
                    x => x.ItemId == source.Item.Id &&
                    x.MinimumAmount.GetValueOrDefault(0) >= source.Quantity &&
                    x.MaximumAmount.GetValueOrDefault(int.MaxValue) <= source.Quantity
                    );
                return model != null ? model.Id : 0;
            }
        }
    }
}
