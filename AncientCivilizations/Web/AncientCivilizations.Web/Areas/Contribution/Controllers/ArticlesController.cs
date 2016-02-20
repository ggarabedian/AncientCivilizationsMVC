namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Web.Mvc;

    using Base;
    using Data.Repositories;
    using Microsoft.AspNet.Identity;
    using Models.Contribution;
    using Services.Contracts;

    public class ArticlesController : ContributionsController
    {
        private IArticleServices articleServices;
        private IPictureServices pictureServices;

        public ArticlesController(IAncientCivilizationsData data, IArticleServices articlesServices, IPictureServices pictureServices)
            : base(data)
        {
            this.articleServices = articlesServices;
            this.pictureServices = pictureServices;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContributeArticleViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.articleServices.Create(model, this.User.Identity.GetUserId());
                return this.RedirectToAction("Index", "Home", new { area = "Contribution" });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            this.TempData["requestUrl"] = this.HttpContext.Request.UrlReferrer;

            var article = this.articleServices.GetArticleForEditing(id);
            return this.View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContributeArticleViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.articleServices.Edit(model, this.User.Identity.GetUserId());
                return this.Redirect(TempData["requestUrl"].ToString());
            }

            return this.View(model);
        }

        public ActionResult GetPictures(string searchQuery)
        {
            var pictures = this.pictureServices.AllBySearchQueryToAddToArticle(searchQuery);
            return this.PartialView("_SelectPicturePartial", pictures);
        }
    }
}