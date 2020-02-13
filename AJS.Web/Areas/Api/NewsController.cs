using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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