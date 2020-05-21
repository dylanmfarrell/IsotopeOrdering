using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Infrastructure.DataServices;
using System;
using Xunit;

namespace IsotopeOrdering.Infrastructure.IntegrationTests.DataServiceTests {
    public class InstitutionServiceTests {
        [Theory, AutoMoqData]
        public async void Get_CurrentCustomer(Customer customer) {
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName, customer.UserId)) {
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName, customer.UserId)) {
                InstitutionService service = new InstitutionService(context, TestUtilities.GetMapper());
                InstitutionItemModel? result = await service.GetInstitutionForCustomer<InstitutionItemModel>(customer.Id);
                Assert.NotNull(result);
            }
        }
    }
}