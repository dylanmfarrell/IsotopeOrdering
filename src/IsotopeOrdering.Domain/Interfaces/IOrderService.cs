using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IOrderService : IService<Order> {
        Task<T?> Get<T>(int id) where T : class;
        Task<T?> GetForStatus<T>(int id, OrderStatus status) where T : class;
        Task<T?> Get<T>(int id, int customerId, int? parentId) where T : class;
        Task<List<T>> GetListForCustomer<T>(int customerId, int? parentId);
        Task<List<T>> GetList<T>();
        Task UpdateStatus(int orderId, OrderStatus status);
        Task AmendOrderItems(List<OrderItem> items);
        Task<List<T>> GetRecipients<T>(int id) where T : class;
    }
}
