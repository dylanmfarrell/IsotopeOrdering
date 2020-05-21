using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IShipmentService : IService<Shipment> {
        Task<T?> Get<T>(int id) where T : class;
        Task<List<T>> GetForOrder<T>(int orderId) where T : class;
        Task<T?> Get<T>(int id, int customerId, int? parentId) where T : class;
        Task<List<T>> GetList<T>();
        Task<List<T>> GetListForCustomer<T>(int customerId, int? parentId);
        Task UpdateStatus(int id, ShipmentStatus status);
    }
}
