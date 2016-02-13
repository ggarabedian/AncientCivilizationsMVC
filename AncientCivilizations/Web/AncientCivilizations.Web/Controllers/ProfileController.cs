namespace AncientCivilizations.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Public;
    using Web.Common.Extensions;

    public class ProfileController : BaseController
    {
        public ProfileController(IAncientCivilizationsData data) : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult UserProfile(string id)
        {
            var data = this.Data.Users.GetById(id);
            var articles = this.Data.Articles.All().Where(a => a.CreatorId == id).To<ArticleViewModel>().ToList();
            var viewModel = Mapper.Map<UserProfileViewModel>(data);
            viewModel.Articles = articles;

            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult _UserProfileInfoPartial(string id)
        {
            var userProfileData = this.Data.Users.GetById(id);
            var articles = this.Data.Articles.All().Where(a => a.CreatorId == id).To<ArticleViewModel>().ToList();
            var viewModel = Mapper.Map<UserProfileViewModel>(userProfileData);
            viewModel.Articles = articles;

            return PartialView(viewModel);
        }

        public ActionResult _UserProfileSettingsPartial(string id)
        {
            var userProfileData = this.Data.Users.GetById(id);
            var viewModel = Mapper.Map<UserProfileViewModel>(userProfileData);
            return PartialView(viewModel);
        }

        public ActionResult _UserProfilePendingPartial(string id)
        {
            var data = this.Data.Articles.All().Where(a => a.CreatorId == id && !a.IsApproved).To<ArticleViewModel>().ToList();

            return PartialView(data);
        }

        public ActionResult _UserProfileContributionsPartial(string id, string sort)
        {
            var data = new List<ArticleViewModel>();

            if (sort == "all")
            {
                data = this.Data.Articles.All().Where(a => a.CreatorId == id && a.IsApproved).To<ArticleViewModel>().ToList();
            }
            else if (sort == "articles")
            {
                data = this.Data.Articles.All().Where(a => a.CreatorId == id && a.IsApproved).To<ArticleViewModel>().ToList();
            }

            return PartialView(data);
        }


        [HttpPost]
        public ActionResult UpdateUserProfile(UserProfileViewModel model, IEnumerable<HttpPostedFileBase> images, string id)
        {
            if (model != null)
            {
                var dbUser = this.Data.Users.GetById(id);

                if (images != null && images.Count() != 0)
                {
                    model.Avatar = ImageEditor.ResizeImageToBitArray(images);
                }
                else
                {
                    model.Avatar = dbUser.Avatar;
                }

                if (ModelState.IsValid)
                {

                    Mapper.Map(model, dbUser);
                    this.Data.Users.SaveChanges();

                    return RedirectToAction("UserProfile", new { id = id });
                }
            }

            return RedirectToAction("_UserProfileSettingsPartial", model);
        }
    }
}