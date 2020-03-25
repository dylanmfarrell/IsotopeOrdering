using IsotopeOrdering.Domain.Entities;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface ICustomerService : IService<Customer> {
        Task<IEnumerable<T>> GetList<T>();
    }
}
