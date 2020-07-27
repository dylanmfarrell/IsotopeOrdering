using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem> {
        public void Configure(EntityTypeBuilder<OrderItem> builder) {
            builder.Property(x => x.Quantity).HasColumnType("decimal(18,2)");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
