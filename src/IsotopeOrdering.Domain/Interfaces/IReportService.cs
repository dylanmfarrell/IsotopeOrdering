using System;
using System.Data;
using System.Threading.Tasks;

namespace IsotopeOrdering.Domain.Interfaces {
    public interface IReportService {
        Task<DataTable> GetBillingReport(DateTime startDate, DateTime endDate);
    }
}
