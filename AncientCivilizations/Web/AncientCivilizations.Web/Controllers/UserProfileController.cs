namespace AncientCivilizations.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    using Models.Public;
    using Services.Contracts;

    [Authorize]
    public class UserProfileController : BaseController
    {
        private IUserProfileServices userServices;

        public UserProfileController(IUserProfileServices userServices)
        {
            this.userServices = userServices;
        }

        [AllowAnonymous]
        public ActionResult Index(string id)
        {
            var user = this.userServices.GetById(id);
            return this.View(user);
        }

        [AllowAnonymous]
        public ActionResult _UserProfileInfoPartial(string id)
        {
            var user = this.userServices.GetById(id);
            return this.PartialView(user);
        }

        public ActionResult _UserProfileSettingsPartial(string id)
        {
            var user = this.userServices.GetById(id);
            return this.PartialView(user);
        }

        public ActionResult _UserProfilePendingPartial(string id)
        {
            var articles = this.userServices.GetPendingArticles(id);
            return this.PartialView(articles);
        }

        [AllowAnonymous]
        public ActionResult _UserProfileArticleContributionsPartial(string id)
        {
            var articles = this.userServices.GetApprovedArticleContributions(id);
            return this.PartialView(articles);
        }

        [AllowAnonymous]
        public ActionResult _UserProfilePictureContributionsPartial(string id)
        {
            var pictures = this.userServices.GetPictureContributions(id);
            return this.PartialView(pictures);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserProfile(UserProfileViewModel model, IEnumerable<HttpPostedFileBase> images, string id)
        {
            if (model != null)
            {
                this.userServices.UpdateUserProfile(model, images);
                return this.RedirectToAction("Index", new { id = id });
            }

            return this.RedirectToAction("_UserProfileSettingsPartial", model);
        }
    }
}