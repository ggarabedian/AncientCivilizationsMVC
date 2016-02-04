namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using ViewModels.Users;

    public class UsersController : AdminController
    {
        public UsersController(IAncientCivilizationsData data)
            : base(data)
        {

        }

        // GET: Administration/Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var users = this.Data
                            .Users
                            .All()
                            .ToDataSourceResult(request);

            return this.Json(users);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.ModifiedOn = DateTime.Now;

                var modelToUpdate = this.Data.Users.All().Where(u => u.Id == model.Id).FirstOrDefault();          
                Mapper.Map(model, modelToUpdate);

                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var user = Mapper.Map<User>(model);
                this.Data.Users.Delete(user);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}