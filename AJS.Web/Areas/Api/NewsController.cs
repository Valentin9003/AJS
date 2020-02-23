using System;
using System.Threading.Tasks;
using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AJS.Web.Areas.Api
{
    /// <summary>
    /// News API Controller
    /// </summary>

    [Route("api/News")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsApiService newsApiService;

        public NewsController(INewsApiService newsApiService)
        {
            this.newsApiService = newsApiService;
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