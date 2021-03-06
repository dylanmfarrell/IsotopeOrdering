﻿using AutoFixture;
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
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class FormManagerTests {
        private readonly ITestOutputHelper _output;
        private readonly NullLogger<FormManager> _logger = new NullLogger<FormManager>();
        private readonly IEventManager _eventService = TestUtilities.GetEventService();

        public FormManagerTests(ITestOutputHelper output) {
            _output = output;
        }

        [Theory, AutoMoqData]
        public async void Get_InitiationForm_For_Customer(CustomerItemModel customer) {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.Get<FormDetailModel>(It.Is<FormType>(x => x == FormType.Initiation))).ReturnsAsync(new FormDetailModel());

            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.GetList<FormInitiationItemModel>()).ReturnsAsync(new List<FormInitiationItemModel>());

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, mockItemService.Object, Mock.Of<IIsotopeOrderingAuthorizationService>(), Mock.Of<ICustomerService>(), _eventService, Mock.Of<INotificationManager>());

            FormDetailModel? model = await manager.GetInitiationForm(customer);
            Assert.Equal(model?.Customer, customer);
        }

        [Theory, AutoMoqData]
        public async void Submit_New_Invalid_InitiationForm_MissingItems(FormDetailModel form) {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.SubmitCustomerForm(It.IsAny<CustomerForm>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, Mock.Of<IItemService>(), Mock.Of<IIsotopeOrderingAuthorizationService>(), Mock.Of<ICustomerService>(), _eventService, Mock.Of<INotificationManager>());

            List<FormInitiationItemModel> items = new List<FormInitiationItemModel>();

            AddressDetailModel address = new Fixture().Create<AddressDetailModel>();
            address.State = "MO";
            address.ZipCode = "12345";
            form.InitiationModel = new FormInitiationDetailModel() {
                Institution = new InstitutionDetailModel() { Id = 1 },
                ShippingAddress = address,
                Items = items
            };

            ApplicationResult result = await manager.SubmitInitiationForm(form);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsExist(result);
        }

        [Theory, AutoMoqData]
        public async void Submit_Existing_Invalid_InitiationForm_InvalidAddress(FormDetailModel form) {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.SubmitCustomerForm(It.IsAny<CustomerForm>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, Mock.Of<IItemService>(), Mock.Of<IIsotopeOrderingAuthorizationService>(), Mock.Of<ICustomerService>(), _eventService, Mock.Of<INotificationManager>());

            List<FormInitiationItemModel> items = new List<FormInitiationItemModel>() {
                new FormInitiationItemModel() {
                    IsSelected = true
                }
            };

            AddressDetailModel address = new Fixture().Create<AddressDetailModel>();
            address.State = "MO123123123123";
            address.ZipCode = "123123123123123123";
            form.InitiationModel = new FormInitiationDetailModel() {
                Institution = new InstitutionDetailModel() { Id = 1 },
                ShippingAddress = address,
                Items = items
            };
            form.CustomerDetailFormId = 1;

            ApplicationResult result = await manager.SubmitInitiationForm(form);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsExist(result);
        }

        [Theory, AutoMoqData]
        public async void Submit_Valid_InitiationForm(FormDetailModel form) {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.SubmitCustomerForm(It.IsAny<CustomerForm>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, Mock.Of<IItemService>(), Mock.Of<IIsotopeOrderingAuthorizationService>(), Mock.Of<ICustomerService>(), _eventService, Mock.Of<INotificationManager>());

            List<FormInitiationItemModel> items = new List<FormInitiationItemModel>() {
                new FormInitiationItemModel() {
                    IsSelected = true
                }
            };
            Fixture fixture = new Fixture();
            AddressDetailModel address = fixture.Create<AddressDetailModel>();
            address.State = "MO";
            address.ZipCode = "12345";

            ContactDetailModel contact = fixture.Create<ContactDetailModel>();
            contact.Email = "test@test.com";
            contact.PhoneNumber = "123-123-1234";
            form.InitiationModel = new FormInitiationDetailModel() {
                Institution = new InstitutionDetailModel() {
                    Name = "Test",
                    Address = address,
                    FinancialContact = contact,
                    SafetyContact = contact
                },
                ShippingAddress = address,
                Items = items
            };
            form.CustomerDetailFormId = 1;
            form.InitiationModel.CustomerAdminSignature.Email = "test@test.com";
            form.InitiationModel.CustomerAdminSignature.PhoneNumber = "123-123-1234";
            ApplicationResult result = await manager.SubmitInitiationForm(form);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsDoNotExist(result);
        }

        [Theory, AutoMoqData]
        public async void Get_CompletedInitiationForm_ReturnsForm(CustomerItemModel customer) {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.GetCustomerForm<FormDetailModel>(customer.Id, It.IsAny<int>())).ReturnsAsync(new FormDetailModel() { Customer = customer });

            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.GetList<FormInitiationItemModel>()).ReturnsAsync(new List<FormInitiationItemModel>());

            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(x => x.GetCurrentCustomer<CustomerItemModel>()).ReturnsAsync(customer);

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, mockItemService.Object, Mock.Of<IIsotopeOrderingAuthorizationService>(), mockCustomerService.Object, _eventService, Mock.Of<INotificationManager>());

            FormDetailModel? model = await manager.GetInitiationForm(1);
            Assert.NotNull(model);
        }

        [Fact]
        public async void Update_Form_Status() {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.UpdateCustomerFormStatus(It.IsAny<int>(), It.IsAny<CustomerFormStatus>())).Returns(Task.CompletedTask);

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, Mock.Of<IItemService>(), Mock.Of<IIsotopeOrderingAuthorizationService>(), Mock.Of<ICustomerService>(), _eventService, Mock.Of<INotificationManager>());

            ApplicationResult result = await manager.UpdateFormStatus(1, 1, CustomerFormStatus.Approved);
            CustomAssertions.AssertValidationErrorsDoNotExist(result);
        }

        [Fact]
        public async void Get_List_AsReviewer() {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.GetCustomerForms<FormItemModel>())
                .ReturnsAsync(new List<FormItemModel>() { new FormItemModel() });

            var mockAuthorizationService = TestUtilities.GetAuthorizationService(Policies.ReviewerPolicy);

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, Mock.Of<IItemService>(), mockAuthorizationService, Mock.Of<ICustomerService>(), _eventService, Mock.Of<INotificationManager>());

            Assert.NotEmpty(await manager.GetList());
        }

        [Fact]
        public async void Get_List_AsCustomer() {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.GetCustomerForms<FormItemModel>(It.IsAny<int>()))
                .ReturnsAsync(new List<FormItemModel>() { new FormItemModel() });

            var mockAuthorizationService = TestUtilities.GetAuthorizationService(Policies.CustomerPolicy);

            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(x => x.GetCurrentCustomer<CustomerItemModel>())
                .ReturnsAsync(new CustomerItemModel());

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, Mock.Of<IItemService>(), mockAuthorizationService, mockCustomerService.Object, _eventService, Mock.Of<INotificationManager>());

            Assert.NotEmpty(await manager.GetList());
        }
    }
}
