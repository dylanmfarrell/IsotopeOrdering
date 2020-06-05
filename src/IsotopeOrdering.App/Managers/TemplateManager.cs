using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using RazorLight;
using System.IO;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class TemplateManager : ITemplateManager {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public TemplateManager(IWebHostEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> GetContent<T>(NotificationTarget target, string templatePath, T model) {
            string templateTypePath = "Template/" + target.ToString();
            string basePath = Path.Combine(_hostingEnvironment.ContentRootPath, templateTypePath);
            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(basePath)
                .UseMemoryCachingProvider()
                .Build();
            return await engine.CompileRenderAsync(templatePath, model);
        }
    }
}
