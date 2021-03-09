using IsotopeOrdering.App.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class ReportManager : IReportManager {
        public async Task<DataTable> GetBillingReport(DateTime startDate, DateTime endDate) { 
            return new DataTable();
        }
    }
}
