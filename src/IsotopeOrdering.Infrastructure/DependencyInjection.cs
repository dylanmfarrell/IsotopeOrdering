using IdentityModel;
using IdentityModel.Client;
using IsotopeOrdering.App.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net.Http;

namespace IsotopeOrdering.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            //Add db connection
            services.AddDbContext<IsotopeOrderingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(IsotopeOrderingDbContext).Assembly.FullName)));

            services.AddScoped<IIsotopeOrderingDbContext>(provider => provider.GetService<IsotopeOrderingDbContext>());

            //Add internal role service
            services.AddMemoryCache();

            services.AddAppManCoreService(x => {
                x.Password = configuration["ApplicationManager:Password"];
                x.UserName = configuration["ApplicationManager:UserName"];
                x.Url = configuration["ApplicationManager:Url"];
            });

            services.AddRoleService(options => {
                options.Token = configuration["ApplicationManager:Token"];
            });

            //Add identity server
            services.AddSingleton<IDiscoveryCache>(r => {
                IHttpClientFactory factory = r.GetRequiredService<IHttpClientFactory>();
                return new DiscoveryCache(configuration["OpenId:Authority"], () => factory.CreateClient());
            });

            services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie(options => {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie.Name = configuration["OpenId:CookieName"];
            })
            .AddOpenIdConnect("oidc", options => {
                options.Authority = configuration["OpenId:Authority"];
                options.RequireHttpsMetadata = false;
                options.ClientId = configuration["OpenId:ClientId"];
                options.ClientSecret = configuration["OpenId:ClientSecret"];
                options.ResponseType = "code id_token";
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");
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
    }
}
