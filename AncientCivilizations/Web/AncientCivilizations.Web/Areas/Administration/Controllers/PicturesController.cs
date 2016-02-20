namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Kendo.Mvc.UI;
    using Models.Administration;

    public class PicturesController : KendoGridAdministrationController
    {
        public PicturesController(IAncientCivilizationsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, PictureViewModel model)
        {
            var updatedModel = base.Update(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, PictureViewModel model)
        {
            base.Delete<Picture>(model);
            return this.GridOperation(model, request);
        }

        public ActionResult GetCategories()
        {
            var categories = this.Data.Categories.All().To<CategoryViewModel>().ToList();
            return this.Json(categories, JsonRequestBehavior.AllowGet);
        }

        protected override object GetById(object id)
        {
            return this.Data.Pictures.GetById(id);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Pictures.All().To<PictureViewModel>();
        }
    }
}