﻿using IsotopeOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsotopeOrdering.Infrastructure.Configurations {
    internal class NotificationSubscriptionConfiguration : IEntityTypeConfiguration<NotificationSubscription> {
        public void Configure(EntityTypeBuilder<NotificationSubscription> builder) {
            //do not configure is deleted query filter
        }
    }
}
