﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace IsotopeOrdering.App {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}
