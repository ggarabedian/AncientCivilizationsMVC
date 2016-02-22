﻿namespace AncientCivilizations.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Common.GlobalConstants;
    using Infrastructure.Mapping;
    using Models.Public;
    using Models.Public.Articles;
    using PagedList;
    using Services.Contracts;

    public class ArticlesController : BaseController
    {
        private IArticleServices articlesServices;
        private ICivilizationServices civilizationServices;

        public ArticlesController(IArticleServices articlesServices, ICivilizationServices civilizationServices) 
        {
            this.articlesServices = articlesServices;
            this.civilizationServices = civilizationServices;
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

            int pageNumber = page ?? 1;

            var articles = this.articlesServices.AllBySearchQuery(searchString, orderBy, civilizationFilter);

            var viewModel = new AllArticlesViewModel()
            {
                Articles = articles.ToPagedList(pageNumber, Common.AllArticlesPageSize),
                CurrentOrder = orderBy,
                CurrentFilter = searchString,
                CivilizationFilter = civilizationFilter,
                Civilizations = this.GetCivilizations(civilizationFilter)
            };

            return this.View(viewModel);
        }

        public ActionResult Detailed(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Detailed article requires id");
            }

            var article = this.articlesServices.GetById(id);

            if (article == null)
            {
                throw new HttpException(400, "No such article exists in the database");
            }

            return this.View(article);
        }

        [HttpGet]
        public ActionResult ExploreMap()
        {
            var civilizations = this.civilizationServices.All().ToList();
            return this.View(civilizations);
        }

        [NonAction]
        private SelectList GetCivilizations(string civilizationFilter)
        {
            var civilizations = this.civilizationServices
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