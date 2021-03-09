using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Infrastructure.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IsotopeOrdering.Infrastructure.IntegrationTests.DataServiceTests {
    public class ItemServiceTests {
        [Theory, AutoMoqData]
        public async void GetListForOrder_Returns_Customers_Item_Configurations(Item item, Customer customer1, Customer customer2) {
            item.Unavailable = false;
            item.ItemConfigurations.Clear();
            customer1.ItemConfigurations = new List<ItemConfiguration>() {
                new ItemConfiguration() { 
                     Item = item,
                     Price = 1,
                     MinimumAmount = 1,
                     MaximumAmount = 2
                }
            };

            customer2.ItemConfigurations = new List<ItemConfiguration>() {
                new ItemConfiguration() {
                     Item = item,
                     Price = 2,
                     MinimumAmount = 1,
                     MaximumAmount = 2
                }
            };
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                context.Customers.Add(customer1);
                context.Customers.Add(customer2);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                ItemService service = new ItemService(context, TestUtilities.GetMapper());
                IEnumerable<OrderItemDetailModel> items1 = await service.GetListForOrder<OrderItemDetailModel>(customer1.Id, null);
                IEnumerable<OrderItemDetailModel> items2 = await service.GetListForOrder<OrderItemDetailModel>(customer2.Id, null);
                foreach (ItemConfigurationDetailModel item1Config in items1.SelectMany(x => x.ItemConfigurations)) {
                    Assert.DoesNotContain(item1Config, items2.Select(x => x.ItemConfiguration));
                }
            }
        }
    }
}
