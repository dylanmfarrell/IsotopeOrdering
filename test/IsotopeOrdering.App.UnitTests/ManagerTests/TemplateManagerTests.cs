using IsotopeOrdering.App.Managers;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System.Dynamic;
using System.IO;
using Xunit;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class TemplateManagerTests {
        [Fact]
        public async void Get_Content_Returns_Template() {
            Mock<IWebHostEnvironment> mock = new Mock<IWebHostEnvironment>();
            mock.SetupGet(x => x.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            TemplateManager manager = new TemplateManager(mock.Object);
            dynamic model = new ExpandoObject();
            model.Name = "Test Name";
            string content = await manager.GetContent<dynamic>(NotificationTarget.Customer, "DefaultTemplate.cshtml", model);
            Assert.Contains(model.Name, content);
        }
    }
}
