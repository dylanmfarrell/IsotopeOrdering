using AutoFixture;
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
using MIR.Core.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class CustomerManagerTests {
        private readonly ITestOutputHelper _output;
        private readonly NullLogger<CustomerManager> _logger = new NullLogger<CustomerManager>();
        private readonly IEventManager _eventService = TestUtilities.GetEventService();

        public CustomerManagerTests(ITestOutputHelper output) {
            _output = output;
        }

        [Fact]
        public async void Initialize_Customer_Does_Not_Exist() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Get<CustomerItemModel>(It.IsAny<string>()))
                .Returns(Task.FromResult<CustomerItemModel?>(null));
            mock.Setup(x => x.Create(It.IsAny<Customer>()))
                .Returns(Task.FromResult(1));
            mock.Setup(x => x.Get<CustomerItemModel>(It.Is<int>(x => x == 1)))
                .Returns(Task.FromResult(new CustomerItemModel() {
                    Contact = {
                        Email = userService.User.Email,
                        FirstName = userService.User.FirstName,
                        LastName = userService.User.LastName,
                   }
                }));
            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, Mock.Of<IIsotopeOrderingAuthorizationService>(), _eventService);

            CustomerItemModel customer = await manager.InitializeCustomerForCurrentUser();

            Assert.Equal(customer.Contact.Email, userService.User.Email);
            Assert.Equal(customer.Contact.FirstName, userService.User.FirstName);
            Assert.Equal(customer.Contact.LastName, userService.User.LastName);
            Assert.Equal(CustomerStatus.New, customer.Status);
        }

        [Fact]
        public async void Initialize_Customer_Does_Exist() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.GetCurrentCustomer<CustomerItemModel>())
                .Returns(Task.FromResult<CustomerItemModel?>(new CustomerItemModel() {
                    Contact = {
                        Email = userService.User.Email,
                        FirstName = userService.User.FirstName,
                        LastName = userService.User.LastName,
                   }
                }));

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, Mock.Of<IIsotopeOrderingAuthorizationService>(), _eventService);

            CustomerItemModel customer = await manager.InitializeCustomerForCurrentUser();

            Assert.Equal(customer.Contact.Email, userService.User.Email);
            Assert.Equal(customer.Contact.FirstName, userService.User.FirstName);
            Assert.Equal(customer.Contact.LastName, userService.User.LastName);
            Assert.Equal(CustomerStatus.New, customer.Status);
        }

        [Fact]
        public async void Get_Customer_List_As_Admin() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());

            IIsotopeOrderingAuthorizationService authorizationService = TestUtilities.GetAuthorizationService(Policies.AdminPolicy);

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.GetList<CustomerItemModel>())
                .Returns(Task.FromResult(new Fixture().CreateMany<CustomerItemModel>().ToList()));

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, authorizationService, _eventService);

            Assert.NotEmpty(await manager.GetList());
        }

        [Fact]
        public async void Get_Customer_List_As_Child_Customer() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            IIsotopeOrderingAuthorizationService authorizationService = TestUtilities.GetAuthorizationService(Policies.CustomerPolicy);

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.GetList<CustomerItemModel>())
                .Returns(Task.FromResult(new Fixture().CreateMany<CustomerItemModel>().ToList()));
            mock.Setup(x => x.GetCurrentCustomer<CustomerItemModel>())
               .Returns(Task.FromResult<CustomerItemModel?>(new CustomerItemModel() {
                   Contact = {
                        Email = userService.User.Email,
                        FirstName = userService.User.FirstName,
                        LastName = userService.User.LastName,
                   },
                   ParentCustomerId = 1
               }));

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, authorizationService, _eventService);
            List<CustomerItemModel> customers = await manager.GetList();
            Assert.True(customers.Count == 1);
        }

        [Fact]
        public async void Get_Customer_List_As_Parent_Customer() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            IIsotopeOrderingAuthorizationService authorizationService = TestUtilities.GetAuthorizationService(Policies.CustomerPolicy);

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.GetList<CustomerItemModel>())
                .Returns(Task.FromResult(new Fixture().CreateMany<CustomerItemModel>().ToList()));
            mock.Setup(x => x.GetCurrentCustomer<CustomerItemModel>())
               .Returns(Task.FromResult<CustomerItemModel?>(new CustomerItemModel() {
                   Contact = {
                        Email = userService.User.Email,
                        FirstName = userService.User.FirstName,
                        LastName = userService.User.LastName,
                   },
                   ParentCustomerId = null
               }));
            mock.Setup(x => x.GetChildrenList<CustomerItemModel>(It.IsAny<int>()))
               .Returns(Task.FromResult(new Fixture().CreateMany<CustomerItemModel>().ToList()));

            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, authorizationService, _eventService);

            Assert.NotEmpty(await manager.GetList());
        }

        [Fact]
        public async void Get_Customer_Details() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            IIsotopeOrderingAuthorizationService authorizationService = TestUtilities.GetAuthorizationService(Policies.AdminPolicy);
            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Get<CustomerDetailModel>(It.IsAny<int>()))
                .ReturnsAsync(new Fixture().Create<CustomerDetailModel>());
            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, authorizationService, _eventService);

            Assert.NotNull(await manager.Get(1));
        }

        [Fact]
        public async void Get_Customer_Details_AsNonAdmin_AsParent() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            IIsotopeOrderingAuthorizationService authorizationService = TestUtilities.GetAuthorizationService(Policies.CustomerPolicy);

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Get<CustomerDetailModel>(It.IsAny<int>()))
                .ReturnsAsync(new Fixture().Create<CustomerDetailModel>());

            mock.Setup(x => x.GetCurrentCustomer<CustomerItemModel>())
                .ReturnsAsync(new CustomerItemModel() {
                    Id = 1
                });

            mock.Setup(x => x.GetChild<CustomerDetailModel>(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new CustomerDetailModel());
            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, authorizationService, _eventService);

            Assert.NotNull(await manager.Get(1));
            Assert.NotNull(await manager.Get(2));
        }

        [Fact]
        public async void Get_Customer_Details_AsNonAdmin_Child() {
            IUserService userService = TestUtilities.GetUserService();
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            IIsotopeOrderingAuthorizationService authorizationService = TestUtilities.GetAuthorizationService(Policies.CustomerPolicy);

            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Get<CustomerDetailModel>(It.IsAny<int>()))
                .ReturnsAsync(new Fixture().Create<CustomerDetailModel>());
            mock.Setup(x => x.GetCurrentCustomer<CustomerItemModel>())
                .ReturnsAsync(new CustomerItemModel() {
                    Id = 2,
                    ParentCustomerId = 1
                });
            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, userService, authorizationService, _eventService);

            Assert.NotNull(await manager.Get(2));
        }


        [Theory, AutoMoqData]
        public async void Edit_Customer_With_Validation_Errors(CustomerDetailModel model) {

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile());
            CustomerManager manager = new CustomerManager(_logger, mapper, Mock.Of<ICustomerService>(), Mock.Of<IUserService>(), Mock.Of<IIsotopeOrderingAuthorizationService>(), _eventService);
            model.Addresses.Clear();

            ApplicationResult applicationResult = await manager.Edit(model);

            _output.WriteLine(applicationResult.Message);
            CustomAssertions.AssertValidationErrorsExist(applicationResult);
        }

        [Theory, AutoMoqData]
        public async void Edit_Customer_Without_Validation_Errors(CustomerDetailModel model) {
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new SharedProfile());
            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Update(It.IsAny<Customer>())).ReturnsAsync(1);

            AddressDetailModel address = new Fixture().Create<AddressDetailModel>();
            address.State = "MO";
            address.ZipCode = "12345";
            model.Addresses.Clear();
            model.Addresses.Add(new CustomerAddressDetailModel() { Address = address, Type = AddressType.Billing });
            model.Addresses.Add(new CustomerAddressDetailModel() { Address = address, Type = AddressType.Shipping });
            model.Contact.Email = "test@test.com";
            model.Contact.Fax = "123-1234";
            model.Contact.PhoneNumber = "123-1234";
            model.Institutions.Clear();
            model.ItemConfigurations.Clear();
            model.Documents.Clear();
            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, Mock.Of<IUserService>(), Mock.Of<IIsotopeOrderingAuthorizationService>(), _eventService);

            ApplicationResult applicationResult = await manager.Edit(model);

            _output.WriteLine(applicationResult.Message);

            CustomAssertions.AssertValidationErrorsDoNotExist(applicationResult);
        }

        [Theory, AutoMoqData]
        public async Task Edit_Customer_Throw_Exception(CustomerDetailModel model) {
            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new SharedProfile());
            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Update(It.IsAny<Customer>())).ThrowsAsync(new Exception("failed"));

            AddressDetailModel address = new Fixture().Create<AddressDetailModel>();
            address.State = "MO";
            address.ZipCode = "12345";
            model.Addresses.Clear();
            model.Addresses.Add(new CustomerAddressDetailModel() { Address = address, Type = AddressType.Billing });
            model.Addresses.Add(new CustomerAddressDetailModel() { Address = address, Type = AddressType.Shipping });
            model.Contact.Email = "test@test.com";
            model.Contact.Fax = "123-1234";
            model.Contact.PhoneNumber = "123-1234";
            model.Institutions.Clear();
            model.ItemConfigurations.Clear();
            model.Documents.Clear();
            CustomerManager manager = new CustomerManager(_logger, mapper, mock.Object, Mock.Of<IUserService>(), Mock.Of<IIsotopeOrderingAuthorizationService>(), _eventService);
            ApplicationResult applicationResult = await manager.Edit(model);
            CustomAssertions.AssertExcpetionErrorsExist(applicationResult);
        }
    }
}
