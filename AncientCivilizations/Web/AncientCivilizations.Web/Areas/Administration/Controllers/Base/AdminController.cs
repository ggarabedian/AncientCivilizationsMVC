namespace AncientCivilizations.Web.Areas.Administration.Controllers.Base
{
    using Data.Repositories;
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