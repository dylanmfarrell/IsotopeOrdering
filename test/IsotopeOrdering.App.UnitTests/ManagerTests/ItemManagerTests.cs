using AutoFixture;
using AutoMapper;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Mappings;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public async void Delete_Item() {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(1);

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            ItemManager manager = new ItemManager(_logger, mapper, mockItemService.Object);

            ApplicationResult result = await manager.DeleteItem(1);
            CustomAssertions.AssertValidationErrorsDoNotExist(result);
        }

        [Fact]
        public async void Get_Item() {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.Get<ItemDetailModel>(It.IsAny<int>())).ReturnsAsync(new ItemDetailModel());

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            ItemManager manager = new ItemManager(_logger, mapper, mockItemService.Object);

            ItemDetailModel model = await manager.GetItem(1);
            Assert.NotNull(model);
        }

        [Fact]
        public async void Get_ItemList() {
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(x => x.GetList<ItemItemModel>()).ReturnsAsync(new Fixture().CreateMany<ItemItemModel>(2).ToList());

            IMapper mapper = TestUtilities.GetMapper(new ItemProfile());
            ItemManager manager = new ItemManager(_logger, mapper, mockItemService.Object);

            List<ItemItemModel> models = await manager.GetList();
            Assert.NotEmpty(models);
        }
    }
}
