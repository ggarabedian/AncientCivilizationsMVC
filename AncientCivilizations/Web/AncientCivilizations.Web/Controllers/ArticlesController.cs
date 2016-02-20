namespace AncientCivilizations.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.Repositories;
    using Models.Public.Articles;
    using PagedList;
    using Services.Contracts;

    public class ArticlesController : BaseController
    {
        private IArticleServices articlesServices;

        public ArticlesController(IAncientCivilizationsData data, IArticleServices articlesServices) 
            : base(data)
        {
            this.articlesServices = articlesServices;
        }

        public ActionResult All(string orderBy, string currentFilter, string searchString, int? page, string civilizationFilter)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            // TODO: Extract constants
            int pageSize = 2;
            int pageNumber = (page ?? 1);

            var articles = this.articlesServices.AllBySearchQuery(searchString, orderBy, civilizationFilter);

            var viewModel = new AllArticlesViewModel()
            {
                Articles = articles.ToPagedList(pageNumber, pageSize),
                CurrentOrder = orderBy,
                CurrentFilter = searchString,
                CivilizationFilter = civilizationFilter,
                Civilizations = this.GetCivilizations(civilizationFilter)
            };

            return View(viewModel);
        }

        public ActionResult Detailed(int id)
        {
            var article = this.articlesServices.GetById(id);
            return View(article);
        }

        [NonAction]
        private SelectList GetCivilizations(string civilizationFilter)
        {
            var civilizations = this.Data
                                    .Civilizations
                                    .All()
                                    .Select(c => new SelectListItem()
                                    {
                                        Text = c.Name,
                                        Value = c.Id.ToString()
                                    });

            return new SelectList(civilizations, "Value", "Text", civilizationFilter);
        }
    }
}