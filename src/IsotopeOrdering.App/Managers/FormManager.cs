using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class FormManager : IFormManager {
        private readonly ILogger<FormManager> _logger;
        private readonly IFormService _service;

        public FormManager(ILogger<FormManager> logger, IFormService service) {
            _logger = logger;
            _service = service;
        }

        public async Task<FormDetailModel> GetCompletedInitiationForm(int customerFormId) {
            throw new System.NotImplementedException();
        }

        public async Task<FormDetailModel> GetInitiationForm() {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationResult> SubmitInitiationForm(FormDetailModel form) {
            throw new System.NotImplementedException();
        }
    }
}
