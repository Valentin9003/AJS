using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AJS.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder CongiguAndUseRequestLocalization(this IApplicationBuilder app)
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
    }
}
