﻿namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using Infrastructure.Caching;
    using Services.Contracts;

    public class HomeController : BaseController
    {
        private IHomeServices homeServices;
        private ICacheService cacheServices;

        public HomeController(IHomeServices homeServices, ICacheService cacheServices)
        {
            this.homeServices = homeServices;
            this.cacheServices = cacheServices;
        }

        public ActionResult Index()
        {
            //// var data = this.cacheServices.Get("HomePageData", () => this.homeServices.GetHomePageData(), 30 * 60);
            var data = this.homeServices.GetHomePageData();
            return this.View(data);
        }
    }
}