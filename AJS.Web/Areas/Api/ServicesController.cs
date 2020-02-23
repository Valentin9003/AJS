using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AJS.Web.Areas.Api
{
    /// <summary>
    ///  Services API Controller 
    /// </summary>
    
    [Route("api/Services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesApiService servicesApiService;

        public ServicesController(IServicesApiService servicesApiService)
        {
            this.servicesApiService = servicesApiService;
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