namespace AncientCivilizations.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Kendo.Mvc.UI;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Administration;

    public class ArticlesController : KendoGridAdministrationController
    {
        public ArticlesController(IAncientCivilizationsData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Articles.All().To<ArticlesViewModel>();
        }


        protected override object GetById(object id)
        {
            return this.Data.Articles.GetById(id);
        }

        public ActionResult ApproveArticle(int id)
        {
            var article = this.Data.Articles.GetById(id);
            article.IsApproved = true;
            article.ApproverId = User.Identity.GetUserId();
            this.Data.Articles.Update(article);
            this.Data.Articles.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ArticlesViewModel model)
        {
            base.Delete<Article>(model);

            return this.GridOperation(model, request);
        }

        public ActionResult GetCategories()
        {
            var categories = this.Data.Categories.All();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}