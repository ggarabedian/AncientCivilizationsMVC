namespace AncientCivilizations.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    using Infrastructure.Caching;
    using Models.Public;
    using Services.Contracts;

    public class PicturesController : BaseController
    {
        private IPictureServices pictureServices;
        private ICacheService cacheServices;

        public PicturesController(IPictureServices pictureServices, ICacheService cacheServices)
        {
            this.pictureServices = pictureServices;
            this.cacheServices = cacheServices;
        }

        public ActionResult All(string searchQuery)
        {
            ////IEnumerable<PicturesViewModel> pictures;

            ////if (string.IsNullOrEmpty(searchQuery))
            ////{
            ////    pictures = this.cacheServices.Get("AllPictures", () => this.pictureServices.AllBySearchQuery(searchQuery), 30 * 60);
            ////}

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