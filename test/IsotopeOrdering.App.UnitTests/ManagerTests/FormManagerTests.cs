﻿using AutoFixture;
using AutoMapper;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Mappings;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class FormManagerTests {
        private readonly ITestOutputHelper _output;
        private readonly NullLogger<FormManager> _logger = new NullLogger<FormManager>();
        private readonly IEventService _eventService = TestUtilities.GetEventService();

        public FormManagerTests(ITestOutputHelper output) {
            _output = output;
        }

        [Theory, AutoMoqData]
        public async void Get_InitiationForm_For_Customer(CustomerItemModel customer) {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.Get<FormDetailModel>(It.Is<FormType>(x => x == FormType.Initiation))).ReturnsAsync(new FormDetailModel());

            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.GetListForInitiation<FormInitiationItemModel>()).ReturnsAsync(new List<FormInitiationItemModel>());

            var mockInstitutionService = new Mock<IInstitutionService>();
            mockInstitutionService.Setup(x => x.GetListForInitiation<InstitutionItemModel>()).ReturnsAsync(new List<InstitutionItemModel>());

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, mockItemService.Object, mockInstitutionService.Object, _eventService);

            FormDetailModel model = await manager.GetInitiationForm(customer);
            Assert.Equal(model.Customer, customer);

        }

        [Theory, AutoMoqData]
        public async void Submit_New_Invalid_InitiationForm_MissingItems(FormDetailModel form) {
            var mockFormService = new Mock<IFormService>();
            mockFormService.Setup(x => x.SubmitCustomerForm(It.IsAny<CustomerForm>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(), new FormProfile(), new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, null, null, _eventService);

            List<FormInitiationItemModel> items = new List<FormInitiationItemModel>();

            AddressDetailModel address = new Fixture().Create<AddressDetailModel>();
            address.State = "MO";
            address.ZipCode = "12345";
            form.InitiationModel = new FormInitiationDetailModel() {
                SelectedInstitution = new InstitutionItemModel() { Id = 1 },
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
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, null, null, _eventService);

            List<FormInitiationItemModel> items = new List<FormInitiationItemModel>() {
                new FormInitiationItemModel() {
                    IsSelected = true
                }
            };

            AddressDetailModel address = new Fixture().Create<AddressDetailModel>();
            address.State = "MO123123123123";
            address.ZipCode = "123123123123123123";
            form.InitiationModel = new FormInitiationDetailModel() {
                SelectedInstitution = new InstitutionItemModel() { Id = 1 },
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
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, null, null, _eventService);

            List<FormInitiationItemModel> items = new List<FormInitiationItemModel>() {
                new FormInitiationItemModel() {
                    IsSelected = true
                }
            };

            AddressDetailModel address = new Fixture().Create<AddressDetailModel>();
            address.State = "MO";
            address.ZipCode = "12345";
            form.InitiationModel = new FormInitiationDetailModel() {
                SelectedInstitution = new InstitutionItemModel() { Id = 1 },
                ShippingAddress = address,
                Items = items
            };
            form.CustomerDetailFormId = 1;

            ApplicationResult result = await manager.SubmitInitiationForm(form);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsDoNotExist(result);
        }
    }
}