using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.Domain.Enums;
using RazorLight;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class TemplateManager : ITemplateManager {
        public async Task<string> GetContent(NotificationTarget target, string templatePath, dynamic model) {
            string templateTypePath = "Templates\\" + target.ToString();
            string basePath = Path.Combine(AppDomain.CurrentDomain!.BaseDirectory!, templateTypePath);
            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(basePath)
                .UseMemoryCachingProvider()
                .Build();
            return await engine.CompileRenderAsync(templatePath, model);
        }
    }
}
