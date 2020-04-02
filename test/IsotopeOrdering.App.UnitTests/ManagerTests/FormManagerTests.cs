using AutoMapper;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Mappings;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
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

            IMapper mapper = TestUtilities.GetMapper(new CustomerProfile(),new FormProfile(),new InstitutionProfile());
            FormManager manager = new FormManager(_logger, mapper, mockFormService.Object, mockItemService.Object, mockInstitutionService.Object, _eventService);

            FormDetailModel model = await manager.GetInitiationForm(customer);
            Assert.Equal(model.Customer, customer);

        }
        [Theory, AutoMoqData]
        public async void SubmitInitiationForm(FormDetailModel form) {

        }
        [Theory, AutoMoqData]
        public async void GetCompletedInitiationForm(int customerFormId) {

        }

        [Theory, AutoMoqData]
        public async void UpdateFormStatus(int customerId, int customerFormId, CustomerFormStatus status) {

        }
    }
}
