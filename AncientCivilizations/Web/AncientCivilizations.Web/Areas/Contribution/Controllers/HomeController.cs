namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Web.Mvc;

    using Web.Controllers;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}