using AutoMapper;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Mappings;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
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
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, Mock.Of<IShipmentService>(), _eventService, Mock.Of<IIsotopeOrderingAuthorizationService>());

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
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, Mock.Of<IShipmentService>(), _eventService, auth);

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
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, Mock.Of<IShipmentService>(), _eventService, auth);

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
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, Mock.Of<IShipmentService>(), _eventService, auth);

            Assert.Null(await manager.GetOrderForm(1));
        }

        [Theory, AutoMoqData]
        public async void Create_Order_Invalid(OrderDetailModel order) {
            var mockItemService = new Mock<IItemService>();

            var mockCustomerService = new Mock<ICustomerService>();

            var mockOrderService = new Mock<IOrderService>();

            order.Cart.Clear();

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile(), new OrderProfile());
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, Mock.Of<IShipmentService>(), _eventService, Mock.Of<IIsotopeOrderingAuthorizationService>());

            CustomAssertions.AssertValidationErrorsExist(await manager.Create(order));
        }

        [Theory, AutoMoqData]
        public async void Create_Order_Valid(OrderDetailModel order) {
            var mockItemService = new Mock<IItemService>();

            var mockCustomerService = new Mock<ICustomerService>();

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.Create(It.IsAny<Order>()))
                .ReturnsAsync(1);

            order.BillingAddress = TestUtilities.GetValidAddress();
            order.ShippingAddress = TestUtilities.GetValidAddress();
            order.Cart.Clear();
            order.Cart.Add(TestUtilities.GetValidOrderItem());
            order.Status = OrderStatus.Sent;

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile(), new OrderProfile(), new SharedProfile());
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, Mock.Of<IShipmentService>(), _eventService, Mock.Of<IIsotopeOrderingAuthorizationService>());

            ApplicationResult result = await manager.Create(order);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsDoNotExist(result);
        }

        [Fact]
        public async void Get_List_For_Customer() {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(x => x.GetCurrentCustomer<CustomerItemModel>())
                .ReturnsAsync(new CustomerItemModel() { Id = 1, ParentCustomerId = null });

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.GetListForCustomer<OrderItemModel>(It.IsAny<int>(), It.IsAny<int?>()))
                .ReturnsAsync(new List<OrderItemModel>() { new OrderItemModel() });
            OrderManager manager = new OrderManager(_logger, Mock.Of<IMapper>(), mockOrderService.Object, Mock.Of<IItemService>(), mockCustomerService.Object, Mock.Of<IShipmentService>(), _eventService, Mock.Of<IIsotopeOrderingAuthorizationService>());

            Assert.NotEmpty(await manager.GetListForCurrentCustomer());
        }


        [Theory, AutoMoqData]
        public async void Edit_Order_Valid(OrderDetailModel order) {
            var mockItemService = new Mock<IItemService>();

            var mockCustomerService = new Mock<ICustomerService>();

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.Update(It.IsAny<Order>()))
                .ReturnsAsync(1);

            order.BillingAddress = TestUtilities.GetValidAddress();
            order.ShippingAddress = TestUtilities.GetValidAddress();
            order.Cart.Clear();
            order.Cart.Add(TestUtilities.GetValidOrderItem());
            order.Status = OrderStatus.Sent;

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile(), new OrderProfile(), new SharedProfile());
            OrderManager manager = new OrderManager(_logger, mapper, mockOrderService.Object, mockItemService.Object, mockCustomerService.Object, Mock.Of<IShipmentService>(), _eventService, Mock.Of<IIsotopeOrderingAuthorizationService>());

            ApplicationResult result = await manager.Edit(order);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsDoNotExist(result);
        }
    }
}
