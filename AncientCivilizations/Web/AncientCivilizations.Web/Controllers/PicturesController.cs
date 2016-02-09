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

        public ActionResult All()
        {
            var pictures = this.Data.Pictures.All().ProjectTo<PicturesViewModel>().ToList();

            return View(pictures);
        }

        public ActionResult DetailedView(int? id)
        {
            var picture = this.Data.Pictures.All().Where(p => p.Id == id).ProjectTo<PicturesViewModel>().FirstOrDefault();

            return View(picture);
        }
    }
}