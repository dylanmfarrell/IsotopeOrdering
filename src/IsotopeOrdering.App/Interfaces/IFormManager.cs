using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IFormManager {
        Task<FormDetailModel> GetInitiationForm();
        Task<ApplicationResult> SubmitInitiationForm(FormDetailModel form);
        Task<FormDetailModel> GetCompletedInitiationForm(int customerFormId);
    }
}
