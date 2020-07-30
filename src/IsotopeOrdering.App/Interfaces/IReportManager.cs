using System.Data;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IReportManager {
        Task<DataTable> GetBillingReport();
    }
}
