namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Base;
    using Data.Models;
    using Data.Repositories;
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
                var dbModel = Mapper.Map<Article>(model);
                dbModel.CreatorId = this.User.Identity.GetUserId();
                this.Data.Articles.Add(dbModel);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index", "Home", new { area = "Contribution" });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = this.Data.Articles.All().Where(a => a.Id == id).ProjectTo<ContributeArticleViewModel>().FirstOrDefault();
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