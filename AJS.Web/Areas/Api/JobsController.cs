using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return new JsonResult("");
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return new JsonResult("");
        }

        [HttpGet("GetByCategory/{categoryName}")]
        public async Task<IActionResult> GetByCategory(string categoryName)
        {
            return new JsonResult("");
        }

        [HttpGet("GetByDate/{publicationDate:datetime}")]
        public async Task<IActionResult> GetByDate(DateTime publicationDate)
        {
            return new JsonResult("");
        }

        [HttpGet("GetByLastDateSync/{lastSyncDate:datetime}")]
        public async Task<IActionResult> GetByLastDateSync(DateTime lastSyncDate)
        {
            return new JsonResult("");
        }
    }
}
