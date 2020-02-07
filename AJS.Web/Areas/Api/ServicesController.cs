using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJS.Web.Areas.Api
{
    [Route("api/Services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceApiService servicesApiService;

        public ServicesController(IServiceApiService servicesApiService)
        {
            this.servicesApiService = servicesApiService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return new JsonResult("Implement me");
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById()
        {
            return new JsonResult("Implement me");
        }

        [HttpGet]
        [Route("GetByCategory")]
        public IActionResult GetByCategory()
        {
            return new JsonResult("Implement me");
        }

        [HttpGet]
        [Route("GetByDate")]
        public IActionResult GetByDate()
        {
            return new JsonResult("Implement me");
        }

        [HttpGet]
        [Route("GetByLastDateSync")]
        public IActionResult GetByLastDateSync()
        {
            return new JsonResult("Implement me");
        }
    }
}