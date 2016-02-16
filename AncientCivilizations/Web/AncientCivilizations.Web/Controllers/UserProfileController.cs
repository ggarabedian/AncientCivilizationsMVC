namespace AncientCivilizations.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    using Data.Repositories;
    using Models.Public;
    using Services.Contracts;

    [Authorize]
    public class UserProfileController : BaseController
    {
        private IUserProfileServices userServices;

        public UserProfileController(IAncientCivilizationsData data, IUserProfileServices userServices) : base(data)
        {
            this.userServices = userServices;
        }

        [AllowAnonymous]
        public ActionResult Index(string id)
        {
            var user = this.userServices.GetById(id);
            return View(user);
        }

        [AllowAnonymous]
        public ActionResult _UserProfileInfoPartial(string id)
        {
            var user = this.userServices.GetById(id);
            return PartialView(user);
        }

        public ActionResult _UserProfileSettingsPartial(string id)
        {
            var user = this.userServices.GetById(id);
            return PartialView(user);
        }

        public ActionResult _UserProfilePendingPartial(string id)
        {
            var articles = this.userServices.GetPendingArticles(id);
            return PartialView(articles);
        }

        [AllowAnonymous]
        public ActionResult _UserProfileAllContributionsPartial(string id)
        {
            var allContent = this.userServices.GetAllApprovedContributions(id);
            return PartialView(allContent);
        }

        [AllowAnonymous]
        public ActionResult _UserProfileArticleContributionsPartial(string id)
        {
            var articles = this.userServices.GetApprovedArticleContributions(id);
            return PartialView(articles);
        }

        [AllowAnonymous]
        public ActionResult _UserProfilePictureContributionsPartial(string id)
        {
            var pictures = this.userServices.GetApprovedPictureContributions(id);
            return PartialView(pictures);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserProfile(UserProfileViewModel model, IEnumerable<HttpPostedFileBase> images, string id)
        {
            if (model != null)
            {
                this.userServices.UpdateUserProfile(model, images, id);
                return RedirectToAction("Index", new { id = id });
            }

            return RedirectToAction("_UserProfileSettingsPartial", model);
        }
    }
}