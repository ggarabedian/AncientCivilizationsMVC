namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Base;
    using Data.Repositories;
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
            return View();
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

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            TempData["requestUrl"] = this.HttpContext.Request.UrlReferrer;

            var article = this.articleServices.GetArticleForEditing(id);
            return View(article);
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

            return View(model);
        }

        public ActionResult GetPictures(string searchQuery)
        {
            var pictures = this.pictureServices.AllBySearchQueryToAddToArticle(searchQuery);
            return PartialView("_SelectPicturePartial", pictures);
        }
    }
}