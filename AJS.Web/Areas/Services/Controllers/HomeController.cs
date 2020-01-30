using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AJS.Web.Areas.Services.Controllers
{
    public class HomeController : BaseServicesController
    {
        private readonly IJobsService jobsService;
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(IJobsService jobsService, IStringLocalizer<HomeController> localizer)
        {
            this.jobsService = jobsService;
            this.localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}