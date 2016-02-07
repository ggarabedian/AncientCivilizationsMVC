namespace AncientCivilizations.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using Data.Repositories;
    using Models.Public;
    using System.Collections.Generic;
    public class PicturesController : BaseController
    {
        public PicturesController(IAncientCivilizationsData data) 
            : base(data)
        {
        }

        public ActionResult All()
        {
            return View(this.GetPictures());
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {           
            return this.Json(this.GetPictures().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<AllPicturesViewModel> GetPictures()
        {
            return this.Data.Pictures.All().ProjectTo<AllPicturesViewModel>().ToList();
        }
    }
}