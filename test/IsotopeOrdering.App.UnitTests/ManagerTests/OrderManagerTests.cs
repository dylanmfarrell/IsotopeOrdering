using AutoMapper;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Mappings;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System.Collections.Generic;
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
            mockCustomerService.Setup(x => x.GetAddressListForOrder<OrderAddressDetailModel>(It.IsAny<int>(), It.IsAny<int?>())).ReturnsAsync(new List<OrderAddressDetailModel>());

            var mockInstitutionService = new Mock<IInstitutionService>();

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, _eventService, Mock.Of<IIsotopeOrderingAuthorizationService>());

            OrderDetailModel result = await manager.GetOrderForm(model);
        }

        [Fact]
        public async void Get_Order_Form_Can_Edit_As_Reviewer() {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.GetListForOrder<OrderItemDetailModel>(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new List<OrderItemDetailModel>());

            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(x => x.GetAddressListForOrder<OrderAddressDetailModel>(It.IsAny<int>(), It.IsAny<int?>()))
                .ReturnsAsync(new List<OrderAddressDetailModel>());

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.Get<OrderDetailModel>(It.IsAny<int>()))
                .ReturnsAsync(new OrderDetailModel() {
                    Status = OrderStatus.Sent,
                    Customer = new CustomerItemModel()
                });

            var auth = TestUtilities.GetAuthorizationService(Policies.ReviewerPolicy);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, _eventService, auth);

            Assert.NotNull(await manager.GetOrderForm(1));
        }

        [Fact]
        public async void Get_Order_Form_Cannot_Edit() {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.GetListForOrder<OrderItemDetailModel>(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new List<OrderItemDetailModel>());

            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(x => x.GetAddressListForOrder<OrderAddressDetailModel>(It.IsAny<int>(), It.IsAny<int?>()))
                .ReturnsAsync(new List<OrderAddressDetailModel>());

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.Get<OrderDetailModel>(It.IsAny<int>()))
                .ReturnsAsync(new OrderDetailModel() {
                    Status = OrderStatus.Approved,
                    Customer = new CustomerItemModel()
                });

            var auth = TestUtilities.GetAuthorizationService(Policies.ReviewerPolicy);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, _eventService, auth);

            Assert.Null(await manager.GetOrderForm(1));
        }

        [Fact]
        public async void Get_Order_Form_Can_Edit_AsCustomer() {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.GetListForOrder<OrderItemDetailModel>(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new List<OrderItemDetailModel>());

            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(x => x.GetAddressListForOrder<OrderAddressDetailModel>(It.IsAny<int>(), It.IsAny<int?>()))
                .ReturnsAsync(new List<OrderAddressDetailModel>());
            mockCustomerService.Setup(x => x.GetCurrentCustomer<CustomerItemModel>())
                .ReturnsAsync(new CustomerItemModel());

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.Get<OrderDetailModel>(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new OrderDetailModel() {
                    Status = OrderStatus.Approved,
                    Customer = new CustomerItemModel()
                });

            var auth = TestUtilities.GetAuthorizationService(Policies.CustomerPolicy);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, _eventService, auth);

            Assert.Null(await manager.GetOrderForm(1));
        }
    }
}
