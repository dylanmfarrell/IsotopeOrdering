using IsotopeOrdering.App.Models.Details;
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
        public async void Get_Customer_Mapping_Correct(Customer customer, NotificationConfiguration configuration) {
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                customer.Subscriptions.Add(new NotificationSubscription() {
                    NotificationConfiguration = configuration,
                    IsDeleted = false
                });
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                CustomerService service = new CustomerService(context, TestUtilities.GetMapper());

                CustomerItemModel item = await service.Get<CustomerItemModel>(customer.Id);
                Assert.Equal(customer.Contact.FirstName, item.Contact.FirstName);

                CustomerDetailModel model = await service.Get<CustomerDetailModel>(customer.Id);
                Assert.NotEmpty(model.SubscriptionConfiguration.Subscriptions);
            }
        }

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

        [Theory, AutoMoqData]
        public async void Get_Mapped_By_Email_Returns_Object(Customer customer) {
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                CustomerService service = new CustomerService(context, TestUtilities.GetMapper());
                CustomerItemModel? result = await service.Get<CustomerItemModel>(customer.UserId);
                Assert.NotNull(result);
                result = await service.Get<CustomerItemModel>("test");
                Assert.Null(result);
            }
        }


        [Theory, AutoMoqData]
        public async void Get_Children_List_Returns_List(Customer customer, Customer child) {
            string instanceName = Guid.NewGuid().ToString();
            child.ParentCustomer = customer;
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                context.Customers.Add(child);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                CustomerService service = new CustomerService(context, TestUtilities.GetMapper());
                List<CustomerItemModel> result = await service.GetChildrenList<CustomerItemModel>(customer.Id);
                Assert.NotEmpty(result);
            }
        }

        [Theory, AutoMoqData]
        public async void Get_Address_List_Returns_List(Customer customer, Customer child) {
            string instanceName = Guid.NewGuid().ToString();
            child.ParentCustomer = customer;
            child.Addresses.Clear();
            customer.ParentCustomerId = null;
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                context.Customers.Add(child);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                CustomerService service = new CustomerService(context, TestUtilities.GetMapper());
                List<CustomerAddressDetailModel> result = await service.GetAddressListForOrder<CustomerAddressDetailModel>(customer.Id, customer.ParentCustomerId);
                Assert.NotEmpty(result);

                result = await service.GetAddressListForOrder<CustomerAddressDetailModel>(child.Id, child.ParentCustomerId);
                Assert.NotEmpty(result);
            }
        }

        [Theory, AutoMoqData]
        public async void Get_CurrentCustomer(Customer customer) {
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName, customer.UserId)) {
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName, customer.UserId)) {
                CustomerService service = new CustomerService(context, TestUtilities.GetMapper());
                CustomerItemModel? result = await service.GetCurrentCustomer<CustomerItemModel>();
                Assert.NotNull(result);
                Assert.Equal(customer.Contact.Email, result!.Contact.Email);
            }
        }

        [Theory, AutoMoqData]
        public async void Search_ReturnsResults(Customer customer) {
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName, customer.UserId)) {
                customer.Status = Domain.Enums.CustomerStatus.Initiated;
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName, customer.UserId)) {
                CustomerService service = new CustomerService(context, TestUtilities.GetMapper());
                List<CustomerSearchResult> results = await service.Search<CustomerSearchResult>(customer.Contact.FirstName);
                Assert.NotEmpty(results);
            }
        }
    }
}
