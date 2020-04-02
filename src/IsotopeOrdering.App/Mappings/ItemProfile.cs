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
            CreateMap<ItemConfiguration, ItemConfigurationDetailModel>()
                .ReverseMap();

            CreateMap<ItemDetailModel, Item>()
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.UpdatedDate, opt => opt.Ignore())
                .ForMember(x => x.IsDeleted, opt => opt.Ignore());
        }
    }
}
