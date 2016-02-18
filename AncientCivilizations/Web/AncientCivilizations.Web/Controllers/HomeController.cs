namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using Data.Repositories;
    using Infrastructure.Caching;
    using Services.Contracts;

    public class HomeController : BaseController
    {
        private IHomeServices homeServices;
        private ICacheService cacheServices;

        public HomeController(IAncientCivilizationsData data, IHomeServices homeServices, ICacheService cacheServices)
            : base(data)
        {
            this.homeServices = homeServices;
            this.cacheServices = cacheServices;
        }

        public ActionResult Index()
        {
            var data = this.cacheServices.Get("HomePageData", () => this.homeServices.GetHomePageData(), 30 * 60);
            return View(data);
        }
    }
}