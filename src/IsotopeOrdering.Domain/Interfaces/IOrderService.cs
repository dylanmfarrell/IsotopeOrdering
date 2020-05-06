﻿using IsotopeOrdering.Domain.Entities;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IOrderService : IService<Order> {
        Task<T?> Get<T>(int id) where T : class;
        Task<T?> Get<T>(int id, int customerId, int? parentId) where T : class;
        Task<List<T>> GetListForCustomer<T>(int customerId, int? parentId);
        Task<List<T>> GetList<T>();
    }
}
