using AutoMapper;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Mappings;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace IsotopeOrdering.App.UnitTests.ManagerTests {
    public class ItemManagerTests {
        private readonly ITestOutputHelper _output;
        private readonly NullLogger<ItemManager> _logger = new NullLogger<ItemManager>();

        public ItemManagerTests(ITestOutputHelper output) {
            _output = output;
        }

        [Theory, AutoMoqData]
        public async void Create_Item_Invalid_MinGreaterThanMax(ItemDetailModel model) {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.Create(It.IsAny<Item>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            ItemManager manager = new ItemManager(_logger, mapper, mockItemService.Object);

            model.MinQuantity = 10;
            model.MaxQuantity = 5;

            ApplicationResult result = await manager.CreateItem(model);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsExist(result);
        }
        
        [Theory, AutoMoqData]
        public async void Create_Item_Invalid_NameEmpty(ItemDetailModel model) {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.Create(It.IsAny<Item>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            ItemManager manager = new ItemManager(_logger, mapper, mockItemService.Object);

            model.Name = string.Empty;
            model.MinQuantity = 10;
            model.MaxQuantity = 10;

            ApplicationResult result = await manager.CreateItem(model);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsExist(result);
        }

        [Theory, AutoMoqData]
        public async void Create_Item_Valid(ItemDetailModel model) {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.Create(It.IsAny<Item>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            ItemManager manager = new ItemManager(_logger, mapper, mockItemService.Object);

            model.MinQuantity = 10;
            model.MaxQuantity = 10;

            ApplicationResult result = await manager.CreateItem(model);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsDoNotExist(result);
        } 
        
        [Theory, AutoMoqData]
        public async void Edit_Item_Invalid_MinGreaterThanMax(ItemDetailModel model) {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.Update(It.IsAny<Item>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            ItemManager manager = new ItemManager(_logger, mapper, mockItemService.Object);

            model.MinQuantity = 10;
            model.MaxQuantity = 5;

            ApplicationResult result = await manager.EditItem(model);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsExist(result);
        }
       
        [Theory, AutoMoqData]
        public async void Edit_Item_Valid(ItemDetailModel model) {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.Update(It.IsAny<Item>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            ItemManager manager = new ItemManager(_logger, mapper, mockItemService.Object);

            model.MinQuantity = 10;
            model.MaxQuantity = 10;

            ApplicationResult result = await manager.EditItem(model);
            _output.WriteLine(result.Message);
            CustomAssertions.AssertValidationErrorsDoNotExist(result);
        }
    }
}
