using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class FormConfiguration : IEntityTypeConfiguration<Form> {
        public void Configure(EntityTypeBuilder<Form> builder) {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
    internal class CustomerDocumentConfiguration : IEntityTypeConfiguration<CustomerDocument> {
        public void Configure(EntityTypeBuilder<CustomerDocument> builder) {
            builder.Property(x => x.UploadId).HasDefaultValue(Guid.NewGuid());
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
