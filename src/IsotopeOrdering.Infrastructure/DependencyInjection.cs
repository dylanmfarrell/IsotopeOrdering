using IdentityModel;
using IdentityModel.Client;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using IsotopeOrdering.Infrastructure.DataServices;
using IsotopeOrdering.Infrastructure.Options;
using IsotopeOrdering.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using MIR.Core.Domain;
using System;
using System.Net.Http;

namespace IsotopeOrdering.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            services.AddIsotopeOrderingDbContext(configuration.GetConnectionString("DefaultConnection"));

            ApplicationManagerOptions applicationManagerOptions = configuration.GetSection("ApplicationManager").Get<ApplicationManagerOptions>();
            services.AddApplicationManagerRoleServices(applicationManagerOptions);

            OpenIdOptions oidcOptions = configuration.GetSection("OpenId").Get<OpenIdOptions>();
            services.AddOidcAuthentication(oidcOptions);

            services.AddSingleton<IUserService, IsotopeUserService>();

            services.AddDataServices();

            return services;
        }

        private static IServiceCollection AddIsotopeOrderingDbContext(this IServiceCollection services, string connectionString) {
            //Add db connection
            services.AddDbContext<IsotopeOrderingDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(IsotopeOrderingDbContext).Assembly.FullName)));
            return services;
        }

        private static IServiceCollection AddApplicationManagerRoleServices(this IServiceCollection services, ApplicationManagerOptions options) {
            //Add internal role service
            services.AddMemoryCache();

            services.AddAppManCoreService(x => {
                x.Password = options.Password;
                x.UserName = options.UserName;
                x.Url = options.Url;
            });

            services.AddRoleService(x => {
                x.Token = options.Token;
                x.DefaultRole = UserRole.Customer.ToString();
            });
            return services;
        }

        private static IServiceCollection AddOidcAuthentication(this IServiceCollection services, OpenIdOptions oidcOptions) {
            //Add identity server
            services.AddSingleton<IDiscoveryCache>(r => {
                IHttpClientFactory factory = r.GetRequiredService<IHttpClientFactory>();
                return new DiscoveryCache(oidcOptions.Authority, () => factory.CreateClient());
            });

            services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie(options => {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie.Name = oidcOptions.CookieName;
            })
            .AddOpenIdConnect("oidc", options => {
                options.Authority = oidcOptions.Authority;
                options.RequireHttpsMetadata = false;
                options.ClientId = oidcOptions.ClientId;
                options.ClientSecret = oidcOptions.ClientSecret;
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                options.Scope.Clear();
                options.Scope.Add(OpenIdConnectScope.OpenIdProfile);
                options.Scope.Add(OpenIdConnectScope.OpenId);
                options.Scope.Add(OpenIdConnectScope.Email);
                options.ClaimActions.MapAllExcept("iss", "nbf", "exp", "aud", "nonce", "iat", "c_hash");
                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role
                };
            });
            return services;
        }

        private static IServiceCollection AddDataServices(this IServiceCollection services) {
            //Add data services
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IInstitutionService, InstitutionService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShipmentService, ShipmentService>();
            services.AddTransient<INotificationService, NotificationService>();
            return services;
        }


    }
}
