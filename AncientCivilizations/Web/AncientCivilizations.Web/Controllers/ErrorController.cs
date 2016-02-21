namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ViewResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }
    }
}