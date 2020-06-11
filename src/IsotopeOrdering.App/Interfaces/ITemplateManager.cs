using IsotopeOrdering.Domain.Enums;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface ITemplateManager {
        Task<string> GetContent<T>(NotificationTarget target, string templatePath, T model);
    }
}
