using FluentValidation.AspNetCore;
using IsotopeOrdering.App;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.Infrastructure;
using IsotopeOrdering.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Net;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI {
    public class Startup {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment) {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddHttpContextAccessor();
            services.AddHttpClient();

            //Add db context, data services, api services, oidc authentication
            services.AddInfrastructure(_configuration, _environment.IsDevelopment());

            //Add logical managers, policies, automapper mappings
            services.AddApplication();

            services.AddHealthChecks().AddDbContextCheck<IsotopeOrderingDbContext>();

            services.AddHostedService<NotificationBackgroundService>();
            services.AddScoped<IScopedNotificationProcessingService, ScopedNotificationProcessingService>();

            services.AddControllersWithViews(x => {
                AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                x.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddRazorRuntimeCompilation()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerDetailModelValidator>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.Use((context, next) => {
                if (!context.Request.Scheme.Contains("https")) {
                    context.Request.Scheme = "https";
                }
                return next();
            });
            app.UseStatusCodePages(async context => {
                await Task.Run(() => {
                    var response = context.HttpContext.Response;
                    if (response.StatusCode == (int)HttpStatusCode.Unauthorized || response.StatusCode == (int)HttpStatusCode.Forbidden) {
                        response.Redirect("/Home/Unauthorized");
                    }
                    else if (response.StatusCode == (int)HttpStatusCode.NotFound) {
                        response.Redirect("/Home/PageNotFound");
                    }
                });
            });
            app.UseStaticFiles();
            app.UseSerilogRequestLogging(options => {
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) => {
                    diagnosticContext.Set("User", httpContext.User.Claims);
                };
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
