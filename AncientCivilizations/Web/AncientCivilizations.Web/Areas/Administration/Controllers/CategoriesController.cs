namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Kendo.Mvc.UI;
    using Models.Administration;

    public class CategoriesController : KendoGridAdministrationController
    {
        public CategoriesController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            var createdModel = base.Create<Category>(model);
            if (createdModel != null)
            {
                model.Id = createdModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            var updatedModel = base.Update(model, model.Id);
            return this.GridOperation(updatedModel, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            this.Delete<Category>(model);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Categories.All();
        }

        protected override object GetById(object id)
        {
            return this.Data.Categories.GetById(id);
        }
    }
}