using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class ShipmentConfiguration : IEntityTypeConfiguration<Shipment> {
        public void Configure(EntityTypeBuilder<Shipment> builder) {
            builder.OwnsOne(x => x.Shipping);
            builder.Property(x => x.UploadId).HasDefaultValue(Guid.NewGuid());
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
