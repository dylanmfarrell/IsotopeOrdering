using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IIsotopeOrderingDbContext {
        IUserService UserService { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerForm> CustomerForms { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemPrice> ItemPrices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderEvent> OrderEvents { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
    }
}
