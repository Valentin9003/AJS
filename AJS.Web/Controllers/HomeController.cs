using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AJS.Web.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;

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
