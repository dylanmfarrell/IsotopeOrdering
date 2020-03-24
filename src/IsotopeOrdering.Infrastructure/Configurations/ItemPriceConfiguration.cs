using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    public class ItemPriceConfiguration : IEntityTypeConfiguration<ItemPrice> {
        public void Configure(EntityTypeBuilder<ItemPrice> builder) {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
