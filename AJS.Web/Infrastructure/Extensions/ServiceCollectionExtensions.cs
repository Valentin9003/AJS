using System;
using AJS.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using AJS.Web.Infrastructure.EmailSenderConfiguration;
using Microsoft.AspNetCore.Identity.UI.Services;
using AJS.Common.Logger;

namespace AJS.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// This method gets called by the runtime services with reflection and creates instances
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>        
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

            return services;
        }

        /// <summary>
        /// This method receive request localization and set Default Allowed Cultures
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection GetRequestLocalization(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo>
                  {
                    new CultureInfo("bg"),
                      new CultureInfo("en"),
                  };

                opts.DefaultRequestCulture = new RequestCulture("bg");

                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;

                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });

            return services;
        }

        /// <summary>
        /// Extension Metod For Add Custom Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
