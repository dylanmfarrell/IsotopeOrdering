using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class CustomerDocumentConfiguration : IEntityTypeConfiguration<CustomerDocument> {
        public void Configure(EntityTypeBuilder<CustomerDocument> builder) {
            builder.OwnsOne(x => x.Document, sa => {
                sa.Property(x => x.Name).HasColumnName("Name");
                sa.Property(x => x.Details).HasColumnName("Details");
                sa.Property(x => x.UploadId).HasColumnName("UploadId");
            });
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
