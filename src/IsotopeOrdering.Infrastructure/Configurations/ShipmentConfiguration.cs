using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class ShipmentConfiguration : IEntityTypeConfiguration<Shipment> {
        public void Configure(EntityTypeBuilder<Shipment> builder) {
            builder.OwnsOne(x => x.Shipping);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
