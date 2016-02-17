namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using Data.Repositories;
    using Services.Contracts;

    public class HomeController : BaseController
    {
        private IHomeServices homeServices;

        public HomeController(IAncientCivilizationsData data, IHomeServices homeServices)
            : base(data)
        {
            this.homeServices = homeServices;
        }

        public ActionResult Index()
        {
            var data = this.homeServices.GetHomePageData();
            return View(data);
        }
    }
}