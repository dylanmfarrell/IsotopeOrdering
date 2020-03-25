using AutoMapper;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace IsotopeOrdering.App {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            services.AddTransient<ICustomerManager, CustomerManager>();
            return services;
        }
    }
}
