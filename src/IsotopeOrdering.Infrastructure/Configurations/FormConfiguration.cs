using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class FormConfiguration : IEntityTypeConfiguration<Form> {
        public void Configure(EntityTypeBuilder<Form> builder) {
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasData(DataSeeding.GetFormSeedData());
        }
    }
}
