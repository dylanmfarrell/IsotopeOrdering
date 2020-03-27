using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class CustomerDocumentConfiguration : IEntityTypeConfiguration<CustomerDocument> {
        public void Configure(EntityTypeBuilder<CustomerDocument> builder) {
            builder.OwnsOne(x => x.Document)
                .Property(x => x.UploadId).HasDefaultValue(Guid.NewGuid());
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
