using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class ShipmentItemConfiguration : IEntityTypeConfiguration<ShipmentItem> {
        public void Configure(EntityTypeBuilder<ShipmentItem> builder) {
            builder.Property(x => x.ShippedRadioactivity).HasColumnType("decimal(18,4)");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
