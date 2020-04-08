using AutoMapper;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace IsotopeOrdering.App {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            services.AddManagers();
            return services;
        }

        private static IServiceCollection AddManagers(this IServiceCollection services) {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<IFormManager, FormManager>();
            services.AddTransient<IItemManager, ItemManager>();
            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<IShipmentManager, ShipmentManager>();
            return services;
        }
    }
}
