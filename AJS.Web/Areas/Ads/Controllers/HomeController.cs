﻿using AJS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AJS.Web.Areas.Ads.Controllers
{
    public class HomeController : BaseAdsController
    {
        private readonly IAdsService adsService;
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(IAdsService adsService, IStringLocalizer<HomeController> localizer)
        {
            this.adsService = adsService;
            this.localizer = localizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This action present a single ad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Ad(string id)
        {
            return View();
        }
    }
}