using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AJS.Web.Areas.Jobs.Controllers
{
    public class HomeController : BaseJobsController
    {
        private readonly IJobsService jobsService;
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(IJobsService jobsService, IStringLocalizer<HomeController> localizer)
        {
            this.jobsService = jobsService;
            this.localizer = localizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}