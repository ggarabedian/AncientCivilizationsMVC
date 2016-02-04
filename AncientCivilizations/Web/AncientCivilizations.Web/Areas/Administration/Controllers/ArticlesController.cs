namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using ViewModels.Content;

    public class ArticlesController : KendoGridAdministrationController
    {
        public ArticlesController(IAncientCivilizationsData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Articles.All();
        }


        protected override object GetById(object id)
        {
            return this.Data.Articles.GetById(id);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ArticlesViewModel model)
        {
            var updatedModel = base.Update(model, model.Id);
            return this.GridOperation(updatedModel, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ArticlesViewModel model)
        {
            base.Delete<Article>(model);

            return this.GridOperation(model, request);
        }

        public ActionResult GetCategories()
        {
            var categories = this.Data.Categories.All();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}