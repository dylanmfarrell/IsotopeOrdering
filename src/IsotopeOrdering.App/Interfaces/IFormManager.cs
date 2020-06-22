using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IFormManager {
        /// <summary>
        /// Gets the MTA form data
        /// </summary>
        /// <returns></returns>
        Task<FormDetailModel> GetInitiationForm(CustomerItemModel customer);
        Task<FormDetailModel?> GetInitiationForm(int id);
        /// <summary>
        /// Validate and save the Initiation Form
        /// </summary>
        /// <param name="form"></param>
        /// <returns>Validation errors and IsSucessful false, otherwise IsSuccessful true</returns>
        Task<ApplicationResult> SubmitInitiationForm(FormDetailModel form);
        /// <summary>
        /// Sets the status of the MTA form, creates an entity event
        /// </summary>
        /// <param name="customerFormId"></param>
        /// <returns></returns>
        Task<ApplicationResult> UpdateFormStatus(int customerId, int customerFormId, CustomerFormStatus status);
        Task<List<FormItemModel>> GetList();
        Task<CustomerFormStatus> GetCustomerInitiationFormStatus(int customerId);

    }
}
