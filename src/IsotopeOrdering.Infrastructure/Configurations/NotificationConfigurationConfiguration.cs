using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class NotificationConfigurationConfiguration : IEntityTypeConfiguration<NotificationConfiguration> {
        public void Configure(EntityTypeBuilder<NotificationConfiguration> builder) {
            builder.HasData(DataSeeding.GetNotificationConfigurationSeedData());
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
