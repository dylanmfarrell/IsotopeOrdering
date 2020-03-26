using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress> {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder) {
            builder.OwnsOne(x => x.Address,
                sa => {
                    sa.Property(x => x.Name).HasColumnName("Name").IsRequired();
                    sa.Property(x => x.State).HasColumnName("State").IsRequired();
                    sa.Property(x => x.City).HasColumnName("City").IsRequired();
                    sa.Property(x => x.ZipCode).HasColumnName("ZipCode").IsRequired();
                    sa.Property(x => x.Address1).HasColumnName("Address1").IsRequired();
                    sa.Property(x => x.Address2).HasColumnName("Address2");
                    sa.Property(x => x.Address3).HasColumnName("Address3");
                });
        }
    }
}
