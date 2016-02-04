namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Web.Mvc;

    using Data.Repositories;
    using Web.Controllers;

    public class HomeController : BaseController
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