using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment> {
        public void Configure(EntityTypeBuilder<Shipment> builder) {
            builder.OwnsOne(x => x.ShippingInformation);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
