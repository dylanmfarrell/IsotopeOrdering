using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class ItemConfigurationConfiguration : IEntityTypeConfiguration<Domain.Entities.ItemConfiguration> {
        public void Configure(EntityTypeBuilder<Domain.Entities.ItemConfiguration> builder) {
            builder.Property(x => x.MaximumAmount).HasColumnType("decimal(18,4)");
            builder.Property(x => x.MinimumAmount).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Price).HasColumnType("decimal(18,4)");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
