namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using Data.Repositories;
    using Services.Contracts;

    public class ArticlesController : BaseController
    {
        private IArticleServices articlesServices;

        public ArticlesController(IAncientCivilizationsData data, IArticleServices articlesServices) 
            : base(data)
        {
            this.articlesServices = articlesServices;
        }

        public ActionResult All(string searchQuery)
        {
            var articles = this.articlesServices.AllBySearchQuery(searchQuery);
            return View(articles);
        }

        public ActionResult Detailed(int id)
        {
            var article = this.articlesServices.GetById(id);
            return View(article);
        }
    }
}