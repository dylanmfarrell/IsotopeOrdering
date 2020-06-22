using AutoMapper;
using FluentValidation.Results;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class ItemManager : IItemManager {
        private readonly ILogger<ItemManager> _logger;
        private readonly IMapper _mapper;
        private readonly IItemService _service;

        public ItemManager(ILogger<ItemManager> logger, IMapper mapper, IItemService service) {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }
        public async Task<ApplicationResult> Create(ItemDetailModel model) {
            ItemDetailModelValidator validator = new ItemDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Item item = _mapper.Map<Item>(model);
                int id = await _service.Create(item);
                return ApplicationResult.Success("Item created", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<ApplicationResult> Delete(int id) {
            int recordsAffected = await _service.Delete(id);
            return ApplicationResult.Success("Item deleted", recordsAffected);
        }

        public async Task<ApplicationResult> Edit(ItemDetailModel model) {
            ItemDetailModelValidator validator = new ItemDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Item item = _mapper.Map<Item>(model);
                int id = await _service.Update(item);
                return ApplicationResult.Success("Item updated", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<ItemDetailModel> Get(int id) {
            return await _service.Get<ItemDetailModel>(id);
        }

        public async Task<List<ItemItemModel>> GetList() {
            return await _service.GetList<ItemItemModel>();
        }

        public async Task<ApplicationResult> ApplyItemConfigurations(OrderDetailModel order) {
            foreach (OrderItemDetailModel item in order.Cart) {
                ItemConfigurationDetailModel? config = await GetItemConfiguration(item.Item.Id, order.Customer.Id, order.Customer.ParentCustomerId, item.Quantity);
                if (config == null) {
                    return ApplicationResult.Error("Failed to find item configuration for customer");
                }
                item.ItemConfiguration = config;
                item.ItemConfigurationId = config.Id;
            }
            return ApplicationResult.Success();
        }

        public async Task<ItemConfigurationDetailModel?> GetItemConfiguration(int itemId, int customerId, int? parentCustomerId, decimal quantity) {
            List<ItemConfiguration> itemConfigurations = await _service.GetItemConfigurations(itemId, parentCustomerId.GetValueOrDefault(customerId));

            //Evaluate most restrictive
            foreach (ItemConfiguration configuration in itemConfigurations.Where(x => x.MaximumAmount.HasValue && x.MinimumAmount.HasValue)) {
                if (quantity >= configuration.MinimumAmount!.Value && quantity <= configuration.MaximumAmount) {
                    return _mapper.Map<ItemConfigurationDetailModel>(configuration);
                }
            }

            //Evaluate less restrictive
            //No minimum but has maximum
            foreach (ItemConfiguration configuration in itemConfigurations.Where(x => x.MaximumAmount.HasValue && !x.MinimumAmount.HasValue)) {
                if (quantity <= configuration.MaximumAmount!.Value) {
                    return _mapper.Map<ItemConfigurationDetailModel>(configuration);
                }
            }

            //No maximum but has minimum
            foreach (ItemConfiguration configuration in itemConfigurations.Where(x => !x.MaximumAmount.HasValue && x.MinimumAmount.HasValue)) {
                if (quantity >= configuration.MinimumAmount!.Value) {
                    return _mapper.Map<ItemConfigurationDetailModel>(configuration);
                }
            }

            return null;
        }
    }
}
