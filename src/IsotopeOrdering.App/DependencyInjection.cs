using AutoMapper;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Managers;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace IsotopeOrdering.App {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            //Add all logic managers
            services.AddManagers();

            //Add policies for admins and customers
            services.AddPolicies();

            //Load all mapping profiles for automapper
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            return services;
        }

        private static IServiceCollection AddPolicies(this IServiceCollection services) {
            services.AddScoped<IIsotopeOrderingAuthorizationService, IsotopeOrderingAuthorizationService>();
            services.AddScoped<IAuthorizationHandler, PolicyHandler>();
            services.AddAuthorizationCore(options => {
                options.AddPolicy(Policies.AdminPolicy, policy => policy.AddRequirements(
                    new RoleRequirement(UserRole.Admin),
                    new AuthorizationRequirement(true)
                ));
                options.AddPolicy(Policies.ReviewerPolicy, policy => policy.AddRequirements(
                    new RoleRequirement(UserRole.Admin, UserRole.Reviewer),
                    new AuthorizationRequirement(true)
                ));
                options.AddPolicy(Policies.CustomerPolicy, policy => policy.AddRequirements(
                    new RoleRequirement(UserRole.Admin, UserRole.Reviewer, UserRole.Customer),
                    new InitiationRequirement(UserRole.Customer, CustomerStatus.Initiated),
                    new AuthorizationRequirement(true)
                ));
                options.AddPolicy(Policies.OrderPolicy, policy => policy.AddRequirements(
                    new RoleRequirement(UserRole.Admin, UserRole.Reviewer, UserRole.Customer),
                    new InitiationRequirement(UserRole.Customer, CustomerStatus.Initiated),
                    new AuthorizationRequirement(true)
                ));
                options.AddPolicy(Policies.PrivatePolicy, policy => policy.AddRequirements(
                     new AuthorizationRequirement(false)
                ));
                options.AddPolicy(Policies.PublicPolicy, policy => policy.AddRequirements(
                     new AuthorizationRequirement(false)
                ));
            });
            return services;
        }

        private static IServiceCollection AddManagers(this IServiceCollection services) {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<IFormManager, FormManager>();
            services.AddTransient<IItemManager, ItemManager>();
            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<IShipmentManager, ShipmentManager>();
            services.AddTransient<IEventManager, EventManager>();
            services.AddTransient<ITemplateManager, TemplateManager>();
            services.AddTransient<INotificationManager, NotificationManager>();
            return services;
        }
    }
}
