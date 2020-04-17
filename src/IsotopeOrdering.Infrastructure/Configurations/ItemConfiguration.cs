using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class ItemConfiguration : IEntityTypeConfiguration<Item> {
        public void Configure(EntityTypeBuilder<Item> builder) {
            builder.Property(x => x.MaxQuantity).HasColumnType("decimal(18,4)");
            builder.Property(x => x.MinQuantity).HasColumnType("decimal(18,4)");
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasData(DataSeeding.GetItemSeedData());
        }
    }
}
