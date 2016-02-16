namespace AncientCivilizations.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;

    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Public;

    public class PicturesController : BaseController
    {
        public PicturesController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public ActionResult All(string query)
        {
            var dbPictures = this.Data.Pictures.All();

            if (!string.IsNullOrEmpty(query))
            {
                dbPictures = dbPictures.Where(p => p.Title.Contains(query) || p.Description.Contains(query) || p.KeyWords.Contains(query));
            }

            var pictures = dbPictures.Take(40).To<PicturesViewModel>()
                                     .ToList();

            return View(pictures);
        }

        public ActionResult Detailed(int? id)
        {
            var picture = this.Data.Pictures.All().Where(p => p.Id == id).To<PicturesViewModel>().FirstOrDefault();

            return View(picture);
        }
    }
}