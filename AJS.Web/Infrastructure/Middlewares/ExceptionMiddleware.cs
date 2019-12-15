using AJS.Web.Controllers;
using AJS.Common.Logger;
using AJS.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AJS.Web.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
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
            catch (Exception ex)
            {
                _logger.LogError($"{ProjectConstants.ErrorLogTitle} {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = ProjectConstants.ContentTypeTextOrHTML;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorViewModel()
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = $"{ProjectConstants.ErrorMessage} {exception.Message}",
                StatusMessage = ProjectConstants.InternalServerError,
                InformationMessage = ProjectConstants.ContactAdministratorMessage
            }.ToString());
        }
    }
}
