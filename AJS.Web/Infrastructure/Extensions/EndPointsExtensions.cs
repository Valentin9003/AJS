using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJS.Web.Infrastructure.Extensions
{
    public static class EndPointsExtensions
    {
        /// <summary>
        /// Extension Method For Add Routes
        /// </summary>
        /// <param name="app"></param>
        public static void UseEndpointsExtension(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");

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
                   name: "News",
                   pattern: "{area:exists}/{controller=News}/{action=index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
