namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Kendo.Mvc.UI;
    using Models.Administration;

    public class UsersController : KendoGridAdministrationController
    {
        public UsersController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            var updatedModel = base.Update(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            base.Delete<User>(model);

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Users.All().To<UserViewModel>();
        }


        protected override object GetById(object id)
        {
            return this.Data.Users.GetById(id);
        }

        ////public ActionResult GiveAdminRights(string id)
        ////{
        ////    var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        ////    var user = this.Data.Users.GetById(id);
        ////    userManager.AddToRole(user.Id, "Administrator");

        ////    return this.RedirectToAction("Index");
        ////}

        ////public ActionResult RevokeAdminRights(int id)
        ////{
        ////    var article = this.Data.Articles.GetById(id);
        ////    article.IsApproved = true;
        ////    article.ApproverId = User.Identity.GetUserId();
        ////    this.Data.Articles.Update(article);
        ////    this.Data.Articles.SaveChanges();

        ////    return this.RedirectToAction("Index");
        ////}
    }
}