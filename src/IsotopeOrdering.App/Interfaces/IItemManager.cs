using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IItemManager {
        Task<ItemItemModel> GetList();
        Task<ItemDetailModel> GetItem(int id);
        Task<ApplicationResult> CreateItem(ItemDetailModel item);
        Task<ApplicationResult> EditItem(ItemDetailModel item);
        Task<ApplicationResult> DeleteItem(int id);
    }
}
