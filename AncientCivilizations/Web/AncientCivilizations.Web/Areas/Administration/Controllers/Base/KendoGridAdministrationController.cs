﻿namespace AncientCivilizations.Web.Areas.Administration.Controllers.Base
{
    using System.Collections;
    using System.Data.Entity;
    using System.Web.Mvc;

    using Data.Repositories;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public abstract class KendoGridAdministrationController : BaseController
    {
        public KendoGridAdministrationController(IAncientCivilizationsData data)
        {
            this.Data = data;
        }

        protected IAncientCivilizationsData Data { get; set; }

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
                var createdModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(createdModel, EntityState.Added);
                return createdModel;
            }

            return null;
        }

        [NonAction]
        protected virtual object Update(object model, object id)
        {
            if (model != null && ModelState.IsValid)
            {
                var modelToUpdate = this.GetById(id);
                Mapper.Map(model, modelToUpdate);
                this.ChangeEntityStateAndSave(modelToUpdate, EntityState.Modified);
                return modelToUpdate;
            }

            return null;
        }

        [NonAction]
        protected virtual void Delete<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var modelToDelete = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(modelToDelete, EntityState.Deleted);
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        protected abstract IEnumerable GetData();

        protected abstract object GetById(object id);

        private void ChangeEntityStateAndSave(object model, EntityState state)
        {
            var entry = this.Data.Context.Entry(model);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}