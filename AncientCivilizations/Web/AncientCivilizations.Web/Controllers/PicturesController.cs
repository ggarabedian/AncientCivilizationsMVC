namespace AncientCivilizations.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Services.Contracts;

    public class PicturesController : BaseController
    {
        private IPictureServices pictureServices;

        public PicturesController(IPictureServices pictureServices)
        {
            this.pictureServices = pictureServices;
        }

        public ActionResult All(string searchQuery)
        {
            var pictures = this.pictureServices.AllBySearchQuery(searchQuery);
            return this.View(pictures);
        }

        public ActionResult Detailed(int? id)
        {
            var picture = this.pictureServices.GetById(id);

            if (picture == null)
            {
                throw new HttpException(400, "No such item exist in the database");
            }

            return this.View(picture);
        }
    }
}