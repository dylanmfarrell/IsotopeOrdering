using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Data;
using MIR.Core.Domain;
using System.Reflection;

namespace IsotopeOrdering.Infrastructure {
    public class IsotopeOrderingDbContext : BaseDataContext<IsotopeOrderingDbContext> {
        public IsotopeOrderingDbContext(IUserService userService, IRoleService roleService) : base(userService) {
            RoleService = roleService;
        }

        public IsotopeOrderingDbContext(IUserService userService, IRoleService roleService, DbContextOptions<IsotopeOrderingDbContext> options) : base(userService, options) {
            RoleService = roleService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
        public DbSet<CustomerDocument> CustomerDocuments { get; set; } = null!;
        public DbSet<CustomerForm> CustomerForms { get; set; } = null!;
        public DbSet<CustomerInstitution> CustomerInstitutions { get; set; } = null!;
        public DbSet<EntityEvent> EntityEvents { get; set; } = null!;
        public DbSet<Form> Forms { get; set; } = null!;
        public DbSet<Institution> Institutions { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<ItemConfiguration> ItemConfigurations { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<NotificationConfiguration> NotificationConfigurations { get; set; } = null!;
        public DbSet<NotificationSubscription> NotificationSubscriptions { get; set; } = null!;
        public DbSet<Shipment> Shipments { get; set; } = null!;
        public DbSet<ShipmentItem> ShipmentItems { get; set; } = null!;
        public IRoleService RoleService { get; }
    }
}
