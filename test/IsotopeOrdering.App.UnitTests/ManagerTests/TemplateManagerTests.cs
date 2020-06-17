using IsotopeOrdering.App.Managers;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.IO;
using Xunit;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class TemplateManagerTests {
        [Fact]
        public async void Get_Content_Returns_Template() {
            Mock<IWebHostEnvironment> mock = new Mock<IWebHostEnvironment>();
            mock.SetupGet(x => x.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            TemplateManager manager = new TemplateManager();
            EntityEvent entityEvent = new EntityEvent();
            entityEvent.Description = "Test Desc";
            entityEvent.EntityId = 1;
            entityEvent.EventDateTime = DateTime.Now;
            string content = await manager.GetContent(NotificationTarget.Customer, "DefaultTemplate.cshtml", entityEvent);
            Assert.Contains(entityEvent.Description, content);
        }
    }
}
