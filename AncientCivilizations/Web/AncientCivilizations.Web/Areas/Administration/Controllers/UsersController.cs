namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using ViewModels.Users;

    public class UsersController : KendoGridAdministrationController
    {
        public UsersController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Users.All();
        }


        protected override object GetById(object id)
        {
            return this.Data.Users.GetById(id);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            var updatedModel = base.Update(model, model.Id);
            return this.GridOperation(updatedModel, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            base.Delete<User>(model);

            return this.GridOperation(model, request);
        }
    }
}