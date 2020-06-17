using IsotopeOrdering.Domain.Enums;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface ITemplateManager {
        Task<string> GetContent(NotificationTarget target, string templatePath, dynamic model);
    }
}
