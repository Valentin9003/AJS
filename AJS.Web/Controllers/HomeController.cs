using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AJS.Web.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System;

namespace AJS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> Logger;
        private readonly IStringLocalizer<HomeController> StringLocalizer;
        private readonly IViewLocalizer ViewLocalizer;
       
        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> stringLocalizer, IViewLocalizer viewLocalizer)
        {
            Logger = logger;
            StringLocalizer = stringLocalizer;
            ViewLocalizer = viewLocalizer;
        }

        public IActionResult Index()
        {
            TempData["Example"] = StringLocalizer.GetString("value");
          
            return View();
        }

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
