namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Contribution;

    public class ArticlesController : ContributionsController
    {
        public ArticlesController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContributeArticleViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Content = HttpUtility.HtmlDecode(model.Content);

                model.CreatorId = this.User.Identity.GetUserId();
                var dbModel = Mapper.Map<Article>(model);
                //var creatorId = this.User.Identity.GetUserId();
                //dbModel.CreatorId = this.User.Identity.GetUserId();
                this.Data.Articles.Add(dbModel);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index", "Home", new { area = "Contribution" });
            }

            return View(model);
        }

        public ActionResult GetPictures(string query)
        {
            var dbPictures = this.Data.Pictures.All();

            if (!string.IsNullOrEmpty(query))
            {
                dbPictures = dbPictures.Where(p => p.Title.Contains(query) || p.Description.Contains(query) || p.KeyWords.Contains(query));
            }

            var pictures = dbPictures.To<ContributePictureViewModel>()
                                     .ToList();

            return PartialView("_SelectPicturePartial", pictures);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var model = this.Data.Articles.All().Where(a => a.Id == id).To<ContributeArticleViewModel>().FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ContributeArticleViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.Data.Articles.GetById(model.Id);
                model.Content = HttpUtility.HtmlDecode(model.Content);
                model.LastEditorId = this.User.Identity.GetUserId();
                Mapper.Map(model, dbModel);
                this.Data.SaveChanges();
                return this.Redirect(Request.UrlReferrer.ToString());
                //TODO : Fix redirecting
            }

            return View(model);
        }
    }
}