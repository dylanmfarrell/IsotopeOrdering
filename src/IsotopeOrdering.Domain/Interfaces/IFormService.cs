using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IFormService : IService<Form> {
        Task<T> Get<T>(FormType formType);
        Task<T?> GetCustomerForm<T>(int customerFormId) where T : class;
        /// <summary>
        /// Creates customer form entry if one does not exist for the form type, 
        /// otherwise updates existing form.
        /// </summary>
        /// <param name="form"></param>
        /// <returns>The id of the customer form</returns>
        Task<int> SubmitCustomerForm(CustomerForm form);
        Task UpdateCustomerFormStatus(int customerFormId, CustomerFormStatus status);
    }
}
