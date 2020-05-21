using IsotopeOrdering.Domain.Entities;
using MIR.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IInstitutionService : IService<Institution> {
        Task<T?> GetInstitutionForCustomer<T>(int customerId) where T : class;
        Task<List<T>> GetListForInitiation<T>();
    }
}
