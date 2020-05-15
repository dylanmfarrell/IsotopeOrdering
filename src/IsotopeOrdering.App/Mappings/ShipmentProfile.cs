using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class ShipmentProfile : Profile {
        public ShipmentProfile() {
            CreateMap<OrderDetailModel, ShipmentDetailModel>()
                .ForMember(x => x.Items, opt => opt.MapFrom(x => x.Cart))
                .ForMember(x => x.Shipping, opt => opt.MapFrom(x => x.ShippingAddress))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<OrderItemDetailModel, ShipmentItemDetailModel>()
                .ForMember(x => x.OrderItem, opt => opt.MapFrom(x => x))
                .ForMember(x => x.OrderItemId, opt => opt.MapFrom(x => x.Id))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<ShipmentDetailModel, Shipment>()
                .ForMember(x => x.Items, opt => opt.MapFrom(x => x.Items))
                .ForMember(x => x.Shipping, opt => opt.MapFrom(x => x.Shipping))
                .ForMember(x => x.ShipmentDate, opt => opt.MapFrom(x => x.ShipmentDate))
                .ForMember(x => x.CourierDetails, opt => opt.MapFrom(x => x.CourierDetails))
                .ForMember(x => x.CourierName, opt => opt.MapFrom(x => x.CourierName))
                .ForMember(x => x.Document, opt => opt.MapFrom(x => x.Document))
                .ForMember(x => x.ShippingCharge, opt => opt.MapFrom(x => x.ShippingCharge))
                .ReverseMap();

            CreateMap<ShipmentItemDetailModel, ShipmentItem>()
                .ForMember(x => x.OrderItemId, opt => opt.MapFrom(x => x.OrderItemId))
                .ForMember(x => x.DamagedReason, opt => opt.MapFrom(x => x.OrderItemId))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status))
                .ForMember(x => x.ShippedRadioactivity, opt => opt.MapFrom(x => x.ShippedRadioactivity))
                .ForMember(x => x.DamagedReason, opt => opt.MapFrom(x => x.DamagedReason))
                .ForMember(x => x.Shipment, opt => opt.Ignore())
                .ForMember(x => x.ShipmentId, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
