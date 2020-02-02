using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using AJS.Web.Infrastructure.Middlewares;
using AJS.Data;
using Microsoft.EntityFrameworkCore;

namespace AJS.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Extention method that migrate Database
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<AJSDbContext>().Database.Migrate();
            }
            return app;
        }

        /// <summary>
        ///  This extension set culture information for requests based on information provided by the client like invoked "UseRequestLocalization" and set "RequestLocalizationOptions"
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestLocalizationExtension(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var options = serviceScope
                    .ServiceProvider
                    .GetRequiredService<IOptions<RequestLocalizationOptions>>();

                app.UseRequestLocalization(options.Value);
            }
            return app;
        }

        /// <summary>
        /// This method set localization information Coockie
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder SetLocalizationCookie(this IApplicationBuilder app)
        {
            var supportedCultures = new List<CultureInfo>
            {
                       new CultureInfo("bg"),
                      new CultureInfo("en"),
            };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("bg"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            // Find the cookie provider with LINQ
            var cookieProvider = localizationOptions.RequestCultureProviders
                .OfType<CookieRequestCultureProvider>()
                .First();

            // Set the new cookie name
            cookieProvider.CookieName = CookieRequestCultureProvider.DefaultCookieName;

            app.UseRequestLocalization(localizationOptions);

            return app;
        }

        /// <summary>
        /// Log middleware that writes full error information to a log file.
        /// </summary>
        /// <param name="app"></param>
        public static void UseLogger(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggerMiddleware>();
        }

        /// <summary>
        /// Extension Method For Add Routes
        /// </summary>
        /// <param name="app"></param>
        public static void UseEndpointsExtension(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "News",
                   pattern: "{area:exists}/{controller=News}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Ads",
                    pattern: "{area:exists}/{controller=Ads}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "Jobs",
                   pattern: "{area:exists}/{controller=Jobs}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "Services",
                   pattern: "{area:exists}/{controller=Services}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
