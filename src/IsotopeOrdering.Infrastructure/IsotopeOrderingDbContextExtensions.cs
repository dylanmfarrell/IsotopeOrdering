using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IsotopeOrdering.Infrastructure {
    public static class IsotopeOrderingDbContextExtensions {
        internal static IQueryable<Customer> Details(this IQueryable<Customer> customers) {
            return customers
                .Include(x => x.Documents)
                .Include(x => x.Addresses)
                .Include(x => x.Institutions)
                .Include(x => x.ItemConfigurations)
                    .ThenInclude(x => x.Item)
                .Include(x => x.Subscriptions)
                    .ThenInclude(x=>x.NotificationConfiguration);
        }

        internal static IQueryable<Customer> Search(this IQueryable<Customer> customers, string search) {
            return customers.Where(x => x.Status == CustomerStatus.Initiated &&
            (x.Contact.FirstName.ToLower().Contains(search.ToLower()) || x.Contact.LastName!.ToLower().Contains(search.ToLower())));
        }

        internal static IQueryable<Order> WhereForCustomer(this IQueryable<Order> orders, int customerId, int? parentId) {
            return orders.Where(x => x.CustomerId == customerId || x.CustomerId == parentId.GetValueOrDefault(0));
        }

        internal static IQueryable<Order> Details(this IQueryable<Order> orders) {
            return orders
                .Include(x => x.Customer)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ItemConfiguration);
        }

        internal static IQueryable<Order> List(this IQueryable<Order> orders) {
            return orders.Include(x => x.Customer)
                .ThenInclude(x => x.Institutions);
        }

        internal static IQueryable<Shipment> WhereForCustomer(this IQueryable<Shipment> shipments, int customerId, int? parentId) {
            return shipments.Where(x => x.Items.Select(x => x.OrderItem).All(x => x.Order.CustomerId == parentId.GetValueOrDefault(customerId)));
        }

        internal static IQueryable<Shipment> WhereForOrder(this IQueryable<Shipment> shipments, int orderId) {
            return shipments.Where(x => x.Items.Any(x => x.OrderItem.OrderId == orderId));
        }

        internal static IQueryable<Shipment> Details(this IQueryable<Shipment> shipments) {
            return shipments
                .Include(x => x.Items)
                    .ThenInclude(x => x.OrderItem)
                        .ThenInclude(x => x.ItemConfiguration)
                .Include(x => x.Items)
                    .ThenInclude(x => x.OrderItem)
                        .ThenInclude(x => x.Order)
                            .ThenInclude(x => x.Customer);
            ;
        }
    }
}