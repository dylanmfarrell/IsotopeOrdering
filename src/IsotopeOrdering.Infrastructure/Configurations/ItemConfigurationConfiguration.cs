using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class ItemConfigurationConfiguration : IEntityTypeConfiguration<Domain.Entities.ItemConfiguration> {
        public void Configure(EntityTypeBuilder<Domain.Entities.ItemConfiguration> builder) {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
