namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Kendo.Mvc.UI;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Models.Administration;

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

        public ActionResult GiveAdminRights(string id)
        {
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = this.Data.Users.GetById(id);
            userManager.AddToRole(user.Id, "Administrator");

            return this.RedirectToAction("Index");
        }

        //public ActionResult RevokeAdminRights(int id)
        //{
        //    var article = this.Data.Articles.GetById(id);
        //    article.IsApproved = true;
        //    article.ApproverId = User.Identity.GetUserId();
        //    this.Data.Articles.Update(article);
        //    this.Data.Articles.SaveChanges();

        //    return this.RedirectToAction("Index");
        //}
    }
}