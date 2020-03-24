using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    public class OrderConfiguration : IEntityTypeConfiguration<Order> {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.OwnsOne(x => x.ShippingInformation);
            builder.OwnsOne(x => x.BillingInformation);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
