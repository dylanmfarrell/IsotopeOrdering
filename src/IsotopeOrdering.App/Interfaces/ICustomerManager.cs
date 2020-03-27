using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface ICustomerManager {
        /// <summary>
        /// Creates a customer record for the current user if one does not exist
        /// </summary>
        /// <returns>CustomerItemModel for the existing or new customer</returns>
        Task<CustomerItemModel> InitializeCustomerForCurrentUser();
        Task<IEnumerable<CustomerItemModel>> GetList();
        Task<CustomerDetailModel> GetCustomer(int id);
        Task<ApplicationResult> EditCustomer(CustomerDetailModel customer);
    }
}
