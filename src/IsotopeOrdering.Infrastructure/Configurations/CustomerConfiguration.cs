using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.OwnsOne(x => x.Contact,
                sa => {
                    sa.Property(x => x.Email).HasColumnName("Email").IsRequired();
                    sa.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
                    sa.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
                    sa.Property(x => x.LastName).HasColumnName("LastName");
                    sa.Property(x => x.Fax).HasColumnName("Fax");
                });
            builder.Property(x => x.Status).HasDefaultValue(CustomerStatus.Pending);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
