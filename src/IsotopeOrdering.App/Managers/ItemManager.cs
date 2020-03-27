using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class ItemManager : IItemManager {
        private readonly ILogger<ItemManager> _logger;
        private readonly IItemService _service;

        public ItemManager(ILogger<ItemManager> logger, IItemService service) {
            _logger = logger;
            _service = service;
        }
        public async Task<ApplicationResult> CreateItem(ItemDetailModel item) {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationResult> DeleteItem(int id) {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationResult> EditItem(ItemDetailModel item) {
            throw new System.NotImplementedException();
        }

        public async Task<ItemDetailModel> GetItem(int id) {
            throw new System.NotImplementedException();
        }

        public async Task<ItemItemModel> GetList() {
            throw new System.NotImplementedException();
        }
    }
}
