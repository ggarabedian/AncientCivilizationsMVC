namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Models.Administration;

    public class CivilizationsController : KendoGridAdministrationController
    {
        public CivilizationsController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Civilizations.All();
        }


        protected override object GetById(object id)
        {
            return this.Data.Civilizations.GetById(id);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, CivilizationViewModel model)
        {
            var dbModel = base.Create<Civilization>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CivilizationViewModel model)
        {
            var updatedModel = base.Update(model, model.Id);
            return this.GridOperation(updatedModel, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, CivilizationViewModel model)
        {
            base.Delete<Civilization>(model);

            return this.GridOperation(model, request);
        }
    }
}