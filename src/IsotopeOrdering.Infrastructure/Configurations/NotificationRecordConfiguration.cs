using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class NotificationRecordConfiguration : IEntityTypeConfiguration<Notification> {
        public void Configure(EntityTypeBuilder<Notification> builder) {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
