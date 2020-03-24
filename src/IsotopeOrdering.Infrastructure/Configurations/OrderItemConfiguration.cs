using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem> {
        public void Configure(EntityTypeBuilder<OrderItem> builder) {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
