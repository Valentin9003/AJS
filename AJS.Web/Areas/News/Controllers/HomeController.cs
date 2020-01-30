using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AJS.Web.Areas.News.Controllers
{
    public class HomeController : BaseNewsController
    {
        private readonly INewsService newsService;
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(INewsService newsService, IStringLocalizer<HomeController> localizer)
        {
            this.newsService = newsService;
            this.localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}