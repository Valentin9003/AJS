using AJS.Common.Logger;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
namespace AJS.Web.Infrastructure.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public LoggerMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await LogExceptionAsync(httpContext, exception);
            }
        }

        private Task LogExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception.ToString());

            return _next(context);
        }
    }
}
