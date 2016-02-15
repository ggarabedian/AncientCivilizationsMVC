namespace AncientCivilizations.Web.Areas.Administration.Controllers.Base
{
    using System.Collections;
    using System.Data.Entity;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Data.Repositories;
    using Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public abstract class KendoGridAdministrationController : BaseController
    {
        public KendoGridAdministrationController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        protected abstract IEnumerable GetData();

        protected abstract object GetById(object id);

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var users = this.GetData()
                            .ToDataSourceResult(request);

            return this.Json(users);
        }

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual object Update(object model, object id)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById(id);
                Mapper.Map(model, dbModel);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Delete<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Deleted);
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private void ChangeEntityStateAndSave(object dbModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dbModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}