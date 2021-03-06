﻿using IsotopeOrdering.Domain.Entities;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IItemService : IService<Item> {
        Task<T> Get<T>(int id);
        Task<List<T>> GetList<T>();
        Task<List<T>> GetListForOrder<T>(int customerId, int? parentCustomerId);
        Task<List<ItemConfiguration>> GetItemConfigurations(int itemId, int customerId);
    }
}
