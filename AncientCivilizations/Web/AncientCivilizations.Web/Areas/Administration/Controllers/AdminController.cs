namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using Data.Contracts;
    using Web.Controllers;

    // [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IAncientCivilizationsData data)
            : base(data)
        {
        }
    }
}