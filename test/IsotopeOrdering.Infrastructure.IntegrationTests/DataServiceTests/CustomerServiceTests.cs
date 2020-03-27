using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Infrastructure.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IsotopeOrdering.Infrastructure.IntegrationTests.DataServiceTests {
    public class CustomerServiceTests {
        [Theory, AutoMoqData]
        public async void Get_List_Returns_Models(Customer customer) {
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                CustomerService service = new CustomerService(context, TestUtilities.GetMapper());
                IEnumerable<CustomerItemModel> customers = await service.GetList<CustomerItemModel>();
                Assert.Equal(customer.Contact.FirstName, customers.ToList().First().Contact.FirstName);
            }
        }
    }
}
