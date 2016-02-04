namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using Data.Contracts;
    using Data.Models;

    public abstract class BaseController : Controller
    {
        public BaseController(IAncientCivilizationsData data)
        {
            this.Data = data;
        }

        protected IAncientCivilizationsData Data { get; set; }

        public User CurrentUser { get; set; }
    }
}