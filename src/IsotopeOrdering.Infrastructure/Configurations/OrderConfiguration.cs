using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class OrderConfiguration : IEntityTypeConfiguration<Order> {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.OwnsOne(x => x.Shipping);
            builder.OwnsOne(x => x.Billing);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
