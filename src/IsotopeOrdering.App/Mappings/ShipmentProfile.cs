using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class ShipmentProfile : Profile {
        public ShipmentProfile() {
            CreateMap<Shipment, ShipmentDetailModel>();
        }
    }
}
