using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AJS.Web.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System;
using AJS.Services.Interfaces;
using System.Threading.Tasks;

namespace AJS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> StringLocalizer;

        private readonly IServiceHelper helper;

        public HomeController(IStringLocalizer<HomeController> stringLocalizer, IViewLocalizer viewLocalizer, IServiceHelper helper)
        {
            StringLocalizer = stringLocalizer;
            this.helper = helper;
        }

        public async Task<IActionResult> Index()
        {
            var context = await helper.GetCurrentHttpContext();
            var lang = await helper.GetUserLocalization();
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
