using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.OwnsOne(x => x.BillingAddress);
            builder.OwnsOne(x => x.ShippingAddress);
            builder.OwnsOne(x => x.CustomerInformation);
            builder.OwnsOne(x => x.RadiationSafetyInformation);
            builder.OwnsOne(x => x.FinancialDepartmentInformation);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
