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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using MIR.Core.Domain;
using System;
using System.Net.Http; 

namespace IsotopeOrdering.Infrastructure {
    public static class DependencyInjection {
        private static bool _isDevelopment;

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isDevelopment) {
            services.ConfigureSettings(configuration, isDevelopment);

            services.AddDbContext(configuration.GetConnectionString("DefaultConnection"));

            services.AddApplicationManagerRoleServices();

            services.AddAuthentication();

            services.AddEmailService();

            services.AddUserService();

            services.AddDataServices();

            return services;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString) {
            //Add db connection
            services.AddDbContext<IsotopeOrderingDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(IsotopeOrderingDbContext).Assembly.FullName)));
            return services;
        }

        private static IServiceCollection AddApplicationManagerRoleServices(this IServiceCollection services) {
            ApplicationManagerOptions options = services.BuildServiceProvider().GetRequiredService<IOptions<ApplicationManagerOptions>>().Value;
            //Add internal role service
            services.AddMemoryCache();

            if (_isDevelopment) {
                services.AddSingleton<IRoleService, DevelopmentRoleService>();
                services.AddSingleton<IAppManCoreService, DevelopmentAppManCoreService>();
            }
            else {
                services.AddAppManCoreService(x => {
                    x.Password = options.Password;
                    x.UserName = options.UserName;
                    x.Url = options.Url;
                });

                services.AddIsotopeOrderingRoleService(x => {
                    x.Token = options.Token;
                    x.DefaultRole = UserRole.Customer.ToString();
                });
            }
            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services) {
            OpenIdOptions options = services.BuildServiceProvider().GetRequiredService<IOptions<OpenIdOptions>>().Value;
            //Add identity server
            if (_isDevelopment) {
                services.AddAuthentication("Development")
                    .AddScheme<AuthenticationSchemeOptions, DevelopmentAuthenticationHandler>("Development", null);
            }
            else {
                services.AddSingleton<IDiscoveryCache>(r => {
                    IHttpClientFactory factory = r.GetRequiredService<IHttpClientFactory>();
                    return new DiscoveryCache(options.Authority, () => factory.CreateClient());
                });

                services.AddAuthentication(options => {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie(x => {
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    x.Cookie.Name = options.CookieName;
                })
                .AddOpenIdConnect("oidc", options => {
                    options.Authority = options.Authority;
                    options.RequireHttpsMetadata = false;
                    options.ClientId = options.ClientId;
                    options.ClientSecret = options.ClientSecret;
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
            }
            return services;
        }

        private static IServiceCollection AddEmailService(this IServiceCollection services) {
            if (_isDevelopment) {
                services.AddSingleton<IEmailService, DevelopmentEmailService>();
            }
            else {
                services.AddSingleton<IEmailService, EmailService>();
            }
            return services;
        }

        private static IServiceCollection AddUserService(this IServiceCollection services) {
            if (_isDevelopment) {
                services.AddSingleton<IUserService, DevelopmentUserService>();
            }
            else {
                services.AddSingleton<IUserService, IsotopeUserService>();
            }
            return services;
        }

        private static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration, bool isDevelopment) {
            services.Configure<ApplicationManagerOptions>(configuration.GetSection("ApplicationManager"));
            services.Configure<OpenIdOptions>(configuration.GetSection("OpenId"));
            services.Configure<EmailOptions>(configuration.GetSection("EmailSettings"));

            IConfigurationSection developmentSettingsSection = configuration.GetSection("DevelopmentSettings");
            services.Configure<DevelopmentOptions>(developmentSettingsSection);
            DevelopmentOptions options = developmentSettingsSection.Get<DevelopmentOptions>();
            if (isDevelopment) {
                _isDevelopment = options.UseDevelopmentSettings;
            }
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
