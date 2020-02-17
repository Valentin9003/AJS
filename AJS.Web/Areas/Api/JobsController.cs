using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AJS.Web.Areas.Api
{
    /// <summary>
    /// Jobs API Controller
    /// </summary>
    
    [Route("api/Jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsApiService jobsApiService;

        public JobsController(IJobsApiService jobsApiService)
        {
            this.jobsApiService = jobsApiService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            return new JsonResult("");
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById()
        {
            return new JsonResult("");
        }

        [HttpGet]
        [Route("GetByCategory")]
        public async Task<IActionResult> GetByCategory()
        {
            return new JsonResult("");
        }

        [HttpGet]
        [Route("GetByDate")]
        public async Task<IActionResult> GetByDate()
        {
            return new JsonResult("");
        }

        [HttpGet]
        [Route("GetByLastDateSync")]
        public async Task<IActionResult> GetByLastDateSync()
        {
            return new JsonResult("");
        }
    }
}
