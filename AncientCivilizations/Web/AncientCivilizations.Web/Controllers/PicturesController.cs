namespace AncientCivilizations.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using Data.Repositories;
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

            var pictures = dbPictures.ProjectTo<PicturesViewModel>()
                                     .ToList();

            return View(pictures);
        }

        public ActionResult DetailedView(int? id)
        {
            var picture = this.Data.Pictures.All().Where(p => p.Id == id).ProjectTo<PicturesViewModel>().FirstOrDefault();

            return View(picture);
        }
    }
}