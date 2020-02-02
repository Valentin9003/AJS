using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AJS.Web.Areas.Services.Controllers
{
    public class HomeController : BaseServicesController
    {
        private readonly IJobsService servicesService;
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(IJobsService servicesService, IStringLocalizer<HomeController> localizer)
        {
            this.servicesService = servicesService;
            this.localizer = localizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}