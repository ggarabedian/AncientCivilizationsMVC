namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using AutoMapper;

    using Data.Models;
    using Data.Repositories;
    using ViewModels;
    using Web.Controllers;

    public class ArticlesController : BaseController
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
        public ActionResult Create(CreateArticleViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<Article>(model);
                dbModel.CreatorId = this.User.Identity.GetUserId();
                this.Data.Articles.Add(dbModel);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index", "Home", new { area = "Contribution" });
            }

            return View(model);
        }

        public ActionResult GetCategories()
        {
            var data = this.Data.Categories.All();
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCivilizations()
        {
            var data = this.Data.Civilizations.All();
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocations()
        {
            var data = this.Data.Locations.All();
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}