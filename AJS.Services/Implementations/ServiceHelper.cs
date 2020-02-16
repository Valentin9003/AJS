using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Threading.Tasks;

namespace AJS.Services.Implementations
{
    /// <summary>
    /// Service Helper
    /// </summary>
    public class ServiceHelper : IServiceHelper
    {
        private readonly IHttpContextAccessor httpAccessor;

        public ServiceHelper(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        /// <summary>
        /// This Method Return Current HTTP Context
        /// </summary>
        /// <returns></returns>
        public HttpContext GetCurrentHttpContext()
        {
            return httpAccessor.HttpContext;
        }

        /// <summary>
        /// This Method Return Current Localization
        /// </summary>
        /// <returns></returns>
        public string GetUserLocalization()
        {
            var httpContext = httpAccessor.HttpContext;

            return  httpContext.Features
                                     .Get<IRequestCultureFeature>()
                                     .RequestCulture.Culture
                                     .Name
                                     .ToString();
        }
    }
}
