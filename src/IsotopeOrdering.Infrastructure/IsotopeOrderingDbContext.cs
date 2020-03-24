using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Data;
using MIR.Core.Domain;
using System.Reflection;

namespace IsotopeOrdering.Infrastructure {
    public class IsotopeOrderingDbContext : BaseDataContext<IsotopeOrderingDbContext>, IIsotopeOrderingDbContext {
        public IsotopeOrderingDbContext(IUserService userService) : base(userService) {
        }

        public IsotopeOrderingDbContext(IUserService userService, DbContextOptions<IsotopeOrderingDbContext> options) : base(userService, options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerForm> CustomerForms { get; set; } = null!;
        public DbSet<Form> Forms { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<ItemPrice> ItemPrices { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderEvent> OrderEvents { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Shipment> Shipments { get; set; } = null!;
        public DbSet<ShipmentItem> ShipmentItems { get; set; } = null!;
    }
}
