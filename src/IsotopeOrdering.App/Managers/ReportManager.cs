using IsotopeOrdering.App.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class ReportManager : IReportManager {
        public Task<DataTable> GetBillingReport() {
            throw new NotImplementedException();
        }
    }
}
