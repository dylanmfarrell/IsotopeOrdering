using AutoFixture;
using AutoMapper;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Mappings;
using IsotopeOrdering.App.Models;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using MIR.Core.Domain;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class CustomerManagerTests {
        private readonly NullLogger<CustomerManager> _logger = new NullLogger<CustomerManager>();

        [Fact]
        public async void Initialize_Customer_Does_Not_Exist() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Get<CustomerItemModel>(It.IsAny<string>()))
                .Returns(Task.FromResult<CustomerItemModel>(null));
            mock.Setup(x => x.Create(It.IsAny<Customer>()))
                .Returns(Task.FromResult(1));
            mock.Setup(x => x.Get<CustomerItemModel>(It.Is<int>(x => x == 1)))
                .Returns(Task.FromResult(new CustomerItemModel() {
                    ContactEmail = userService.User.Email,
                    ContactFirstName = userService.User.FirstName,
                    ContactLastName = userService.User.LastName
                }));
            ;

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, null);

            CustomerItemModel customer = await manager.InitializeCustomerForCurrentUser();

            Assert.Equal(customer.ContactEmail, userService.User.Email);
            Assert.Equal(customer.ContactFirstName, userService.User.FirstName);
            Assert.Equal(customer.ContactLastName, userService.User.LastName);
            Assert.True(customer.Status == CustomerStatus.Pending);
        }

        [Fact]
        public async void Initialize_Customer_Does_Exist() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Get<CustomerItemModel>(It.IsAny<string>()))
                .Returns(Task.FromResult(new CustomerItemModel() {
                    ContactEmail = userService.User.Email,
                    ContactFirstName = userService.User.FirstName,
                    ContactLastName = userService.User.LastName
                }));

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, null);

            CustomerItemModel customer = await manager.InitializeCustomerForCurrentUser();

            Assert.Equal(customer.ContactEmail, userService.User.Email);
            Assert.Equal(customer.ContactFirstName, userService.User.FirstName);
            Assert.Equal(customer.ContactLastName, userService.User.LastName);
            Assert.True(customer.Status == CustomerStatus.Pending);
        }

        [Fact]
        public async void Get_Customer_List_As_Admin() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.SetupGet(x => x.UserRoles).Returns(new[] { UserRole.Admin.ToString() });

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.GetList<CustomerItemModel>())
                .Returns(Task.FromResult(new Fixture().CreateMany<CustomerItemModel>()));

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, mockRoleService.Object);

            Assert.NotEmpty(await manager.GetList());
        }

        [Fact]
        public async void Get_Customer_List_As_Child_Customer() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.SetupGet(x => x.UserRoles).Returns(new[] { UserRole.Customer.ToString() });

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.GetList<CustomerItemModel>())
                .Returns(Task.FromResult(new Fixture().CreateMany<CustomerItemModel>()));
            mock.Setup(x => x.Get<CustomerItemModel>(It.IsAny<string>()))
               .Returns(Task.FromResult(new CustomerItemModel() {
                   ContactEmail = userService.User.Email,
                   ContactFirstName = userService.User.FirstName,
                   ContactLastName = userService.User.LastName,
                   ParentCustomerId = 1
               }));

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, mockRoleService.Object);

            Assert.Empty(await manager.GetList());
        }

        [Fact]
        public async void Get_Customer_List_As_Parent_Customer() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            var mockRoleService = new Mock<IRoleService>();
            mockRoleService.SetupGet(x => x.UserRoles).Returns(new[] { UserRole.Customer.ToString() });

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.GetList<CustomerItemModel>())
                .Returns(Task.FromResult(new Fixture().CreateMany<CustomerItemModel>()));
            mock.Setup(x => x.Get<CustomerItemModel>(It.IsAny<string>()))
               .Returns(Task.FromResult(new CustomerItemModel() {
                   ContactEmail = userService.User.Email,
                   ContactFirstName = userService.User.FirstName,
                   ContactLastName = userService.User.LastName,
                   ParentCustomerId = null
               }));
            mock.Setup(x => x.GetChildrenList<CustomerItemModel>(It.IsAny<int>()))
               .Returns(Task.FromResult(new Fixture().CreateMany<CustomerItemModel>()));

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, mockRoleService.Object);

            Assert.NotEmpty(await manager.GetList());
        }

        [Fact]
        public async void Get_Customer_Details() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Get<CustomerDetailModel>(It.IsAny<int>()))
                .ReturnsAsync(new Fixture().Create<CustomerDetailModel>());
            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, null);

            Assert.NotNull(await manager.GetCustomer(1));
        }
    }
}
