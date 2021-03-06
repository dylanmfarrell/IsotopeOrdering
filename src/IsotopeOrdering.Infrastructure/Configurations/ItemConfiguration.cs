﻿using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class ItemConfiguration : IEntityTypeConfiguration<Item> {
        public void Configure(EntityTypeBuilder<Item> builder) {
            builder.Property(x => x.DefaultMaxQuantity).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DefaultMinQuantity).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DefaultPrice).HasColumnType("decimal(18,2)");
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasData(DataSeeding.GetItemSeedData());
        }
    }
}
