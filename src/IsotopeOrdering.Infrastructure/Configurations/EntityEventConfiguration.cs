using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class EntityEventConfiguration : IEntityTypeConfiguration<EntityEvent> {
        public void Configure(EntityTypeBuilder<EntityEvent> builder) {
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.EventDateTime).IsRequired();
        }
    }
}
