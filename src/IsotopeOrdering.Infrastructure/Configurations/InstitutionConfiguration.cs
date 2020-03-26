using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class InstitutionConfiguration : IEntityTypeConfiguration<Institution> {
        public void Configure(EntityTypeBuilder<Institution> builder) {
            builder.OwnsOne(x => x.FinancialContact);
            builder.OwnsOne(x => x.SafetyContact);
            builder.OwnsOne(x => x.Address);
            builder.Property(x => x.UploadId).HasDefaultValue(Guid.NewGuid());
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
