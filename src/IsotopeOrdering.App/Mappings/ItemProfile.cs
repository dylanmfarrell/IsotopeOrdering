using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;

namespace IsotopeOrdering.App.Mappings {
    public class ItemProfile : Profile {
        public ItemProfile() {
            CreateMap<Item, ItemDetailModel>();
            CreateMap<Item, ItemItemModel>();
            CreateMap<ItemConfiguration, ItemConfigurationDetailModel>();
        }
    }
}
