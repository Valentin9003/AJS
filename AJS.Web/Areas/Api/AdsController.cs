using AJS.Services.Interfaces;
using AJS.Web.Areas.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AJS.Web.Areas.Api
{
    /// <summary>
    /// Ads API Controller
    /// </summary>

    [Route("api/Ads")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdsApiService adsApiService;
        private readonly IMapper mapper;

        public AdsController(IAdsApiService adsApiService, IMapper mapper)
        {
            this.adsApiService = adsApiService;
            this.mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var ads = await adsApiService.GetAllAds();
            var result = mapper.Map<AdApiModel>(ads);
            return new JsonResult(result);
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
            return  new JsonResult("");
        }
    }
}