using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using AJS.Web.Infrastructure.Middlewares;

namespace AJS.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtentions
    {
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
        /// Custom Global Exception Middleware that shows only the error and writes full error information to a log file.
        /// </summary>
        /// <param name="app"></param>
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
