using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IItemManager {
        Task<List<ItemItemModel>> GetList();
        Task<ItemDetailModel> Get(int id);
        Task<ApplicationResult> Create(ItemDetailModel item);
        Task<ApplicationResult> Edit(ItemDetailModel item);
        Task<ApplicationResult> Delete(int id);
        Task ApplyItemConfigurations(OrderDetailModel order);
        Task<int> GetItemConfigurationId(int itemId, int customerId, int? parentCustomerId, decimal quantity);
    }
}
