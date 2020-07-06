using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class ShipmentConfiguration : IEntityTypeConfiguration<Shipment> {
        public void Configure(EntityTypeBuilder<Shipment> builder) {
            builder.Property(x => x.ShippingCharge).HasColumnType("decimal(18,4)");
            builder.OwnsOne(x => x.Shipping, sa => {
                sa.Property(x => x.Name).HasColumnName("AddressName").IsRequired();
                sa.Property(x => x.Country).HasColumnName("Country").IsRequired();
                sa.Property(x => x.State).HasColumnName("State");
                sa.Property(x => x.City).HasColumnName("City").IsRequired();
                sa.Property(x => x.ZipCode).HasColumnName("ZipCode").IsRequired();
                sa.Property(x => x.Address1).HasColumnName("Address1").IsRequired();
                sa.Property(x => x.Address2).HasColumnName("Address2");
                sa.Property(x => x.Address3).HasColumnName("Address3");
            });
            builder.OwnsOne(x => x.Document);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
