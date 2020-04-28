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
        /// <summary>
        /// Returns a list of customers based on the current users policy
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerItemModel>> GetList();
        Task<List<CustomerItemModel>> GetListForOrder();
        Task<CustomerDetailModel?> Get(int id);
        Task<CustomerItemModel?> GetItem(int id);
        Task<CustomerItemModel?> GetCurrentCustomer();
        Task<ApplicationResult> Edit(CustomerDetailModel customer);
    }
}
