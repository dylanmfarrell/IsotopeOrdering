using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class InstitutionConfiguration : IEntityTypeConfiguration<Institution> {
        public void Configure(EntityTypeBuilder<Institution> builder) {
            builder.OwnsOne(x => x.FinancialContact);
            builder.OwnsOne(x => x.SafetyContact);
            builder.OwnsOne(x => x.Address, sa => {
                sa.Property(x => x.Name).HasColumnName("AddressName").IsRequired();
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
