namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Web.Mvc;

    using Base;
    using Data.Repositories;

    public class HomeController : ContributionsController
    {
        public HomeController(IAncientCivilizationsData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}