using FluentValidation.AspNetCore;
using IsotopeOrdering.App;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MIR.Core.Domain;
using MIR.Core.Mvc.Security;
using Serilog;

namespace IsotopeOrdering.UI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddHttpContextAccessor();
            services.AddHttpClient();

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddScoped<IUserService, UserService>();

            services.AddHealthChecks().AddDbContextCheck<IsotopeOrderingDbContext>();

            services.AddControllersWithViews(x => {
                AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                x.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerDetailModelValidator>())
            .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseNotFoundHandler();
            app.Use((context, next) => {
                if (!context.Request.Scheme.Contains("https")) {
                    context.Request.Scheme = "https";
                }
                return next();
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
