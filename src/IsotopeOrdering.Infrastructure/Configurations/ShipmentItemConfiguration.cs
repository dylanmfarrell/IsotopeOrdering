﻿using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    public class ShipmentItemConfiguration : IEntityTypeConfiguration<ShipmentItem> {
        public void Configure(EntityTypeBuilder<ShipmentItem> builder) {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
