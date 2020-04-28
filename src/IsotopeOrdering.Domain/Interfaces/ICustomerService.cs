using IsotopeOrdering.Domain.Entities;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface ICustomerService : IService<Customer> {
        Task<T?> GetCurrentCustomer<T>() where T : class;
        Task<T?> Get<T>(string userId) where T : class;
        Task<T> Get<T>(int id) where T : class;
        Task<List<T>> GetListForOrder<T>() where T : class;
        Task<List<T>> GetList<T>() where T : class;
        Task<List<T>> GetChildrenList<T>(int parentId) where T : class;
        Task<T> GetChild<T>(int parentId, int childId) where T : class;
        Task<List<T>> GetAddressListForOrder<T>(int customerId, int? parentCustomerId) where T : class;
    }
}
