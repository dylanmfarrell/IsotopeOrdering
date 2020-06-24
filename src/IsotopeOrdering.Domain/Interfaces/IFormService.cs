using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IFormService : IService<Form> {
        Task<T> Get<T>(FormType formType);
        /// <summary>
        /// Creates customer form entry if one does not exist for the form type, 
        /// otherwise updates existing form.
        /// </summary>
        /// <param name="form"></param>
        /// <returns>The id of the customer form</returns>
        Task<int> SubmitCustomerForm(CustomerForm form);
        Task UpdateCustomerFormStatus(int customerFormId, CustomerFormStatus status);
        Task<List<T>> GetCustomerForms<T>();
        Task<List<T>> GetCustomerForms<T>(int customerId);
        Task<T?> GetCustomerForm<T>(int customerId, int customerFormId) where T : class;
        Task<T?> GetCustomerForm<T>(int customerFormId) where T : class;
        /// <summary>
        /// Gets form where status is awaiting customer supervisor approval by form identifier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="formIdentifier"></param>
        /// <returns></returns>
        Task<T?> GetCustomerForm<T>(Guid formIdentifier) where T : class;
        Task<CustomerFormStatus> GetInitiationFormStatus(int customerId);
    }
}
