﻿using AutoMapper;
using FluentValidation.Results;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
        public async Task<ApplicationResult> CreateItem(ItemDetailModel model) {
            ItemDetailModelValidator validator = new ItemDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Item item = _mapper.Map<Item>(model);
                int id = await _service.Create(item);
                return ApplicationResult.Success("Item created", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<ApplicationResult> DeleteItem(int id) {
            int recordsAffected = await _service.Delete(id);
            return ApplicationResult.Success("Item deleted", recordsAffected);
        }

        public async Task<ApplicationResult> EditItem(ItemDetailModel model) {
            ItemDetailModelValidator validator = new ItemDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                Item item = _mapper.Map<Item>(model);
                int id = await _service.Update(item);
                return ApplicationResult.Success("Item updated", id);
            }
            return ApplicationResult.Error(result);
        }

        public async Task<ItemDetailModel> GetItem(int id) {
            return await _service.Get<ItemDetailModel>(id);
        }

        public async Task<List<ItemItemModel>> GetList() {
            return await _service.GetList<ItemItemModel>();
        }
    }
}