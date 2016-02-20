namespace AncientCivilizations.Web.Areas.Contribution.Controllers.Base
{
    using System.Web.Mvc;

    using Data.Repositories;
    using Web.Controllers;

    // [Authorize(Roles = "User", "Admin")]
    public abstract class ContributionsController : BaseController
    {
        public ContributionsController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        [OutputCache(Duration = 30 * 60)]
        public ActionResult GetCategories()
        {
            var data = this.Data.Categories.All();
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 30 * 60)]
        public ActionResult GetCivilizations()
        {
            var data = this.Data.Civilizations.All();
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 30 * 60)]
        public ActionResult GetLocations()
        {
            var data = this.Data.Locations.All();
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}