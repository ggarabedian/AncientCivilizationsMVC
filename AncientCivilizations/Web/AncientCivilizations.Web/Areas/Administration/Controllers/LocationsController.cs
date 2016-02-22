namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Kendo.Mvc.UI;
    using Models.Administration;

    public class LocationsController : KendoGridAdministrationController
    {
        public LocationsController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, LocationViewModel model)
        {
            var createdModel = base.Create<Location>(model);
            if (createdModel != null)
            {
                model.Id = createdModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, LocationViewModel model)
        {
            var updatedModel = base.Update(model, model.Id);
            return this.GridOperation(updatedModel, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, LocationViewModel model)
        {
            this.Delete<Location>(model);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Locations.All();
        }

        protected override object GetById(object id)
        {
            return this.Data.Locations.GetById(id);
        }
    }
}