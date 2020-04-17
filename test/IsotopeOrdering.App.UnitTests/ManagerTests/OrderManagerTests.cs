using AutoMapper;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Mappings;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class OrderManagerTests {
        private readonly ITestOutputHelper _output;
        private readonly NullLogger<OrderManager> _logger = new NullLogger<OrderManager>();
        private readonly IEventManager _eventService = TestUtilities.GetEventService();
        public OrderManagerTests(ITestOutputHelper output) {
            _output = output;
        }

        [Theory, AutoMoqData]
        public async void Get_Order_Form_As_Parent(CustomerItemModel model) {
            model.ParentCustomerId = null;
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.Create(It.IsAny<Item>())).ReturnsAsync(1);

            var mockOrderService = new Mock<IOrderService>();

            var mockCustomerService = new Mock<ICustomerService>();

            var mockInstitutionService = new Mock<IInstitutionService>();

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, mockInstitutionService.Object, _eventService);

            OrderDetailModel result = await manager.GetOrderForm(model);
        }

    }
}
