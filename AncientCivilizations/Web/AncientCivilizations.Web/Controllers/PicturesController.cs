namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using Data.Repositories;
    using Services.Contracts;

    public class PicturesController : BaseController
    {
        private IPictureServices pictureServices;

        public PicturesController(IAncientCivilizationsData data, IPictureServices pictureServices)
            : base(data)
        {
            this.pictureServices = pictureServices;
        }

        public ActionResult All(string searchQuery)
        {
            var pictures = this.pictureServices.AllBySearchQuery(searchQuery);
            return View(pictures);
        }

        public ActionResult Detailed(int? id)
        {
            var picture = this.pictureServices.GetById(id);
            return View(picture);
        }
    }
}