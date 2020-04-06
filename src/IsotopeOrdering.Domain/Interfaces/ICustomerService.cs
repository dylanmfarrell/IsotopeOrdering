using IsotopeOrdering.Domain.Entities;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface ICustomerService : IService<Customer> {
        Task<T?> Get<T>(string email) where T : class;
        Task<T> Get<T>(int id) where T : class;
        Task<List<T>> GetList<T>() where T : class;
        Task<List<T>> GetChildrenList<T>(int parentId) where T : class;
        Task<List<T>> GetAddressesForOrder<T>(int customerId, int? parentCustomerId);
    }
}
