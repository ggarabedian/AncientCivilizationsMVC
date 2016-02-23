namespace AncientCivilizations.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Base;
    using Contracts;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Helpers;
    using Infrastructure.Mapping;
    using Models.Contribution;
    using Models.Public;

    public class ArticleServices : BaseServices, IArticleServices
    {
        public ArticleServices(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public IQueryable<ArticleViewModel> All()
        {
            return this.Data.Articles.All().To<ArticleViewModel>();
        }

        public IEnumerable<ArticleViewModel> AllBySearchQuery(string searchString, string orderBy, string civilizationFilter, string categoryFilter)
        {
            var articles = this.Data.Articles.All().Where(a => a.IsApproved);

            if (!string.IsNullOrEmpty(civilizationFilter) && civilizationFilter != "All")
            {
                int id = int.Parse(civilizationFilter);
                articles = articles.Where(a => a.CivilizationId == id);
            }

            if (!string.IsNullOrEmpty(categoryFilter) && categoryFilter != "All")
            {
                int id = int.Parse(categoryFilter);
                articles = articles.Where(a => a.CategoryId == id);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Title.Contains(searchString)
                                       || s.KeyWords.Contains(searchString));
            }

            switch (orderBy)
            {
                case "Name":
                    articles = articles.OrderBy(a => a.Title);
                    break;
                case "Date":
                    articles = articles.OrderByDescending(a => a.CreatedOn);
                    break;
                default:
                    articles = articles.OrderByDescending(s => s.CreatedOn);
                    break;
            }

            var viewModel = articles.To<ArticleViewModel>().ToList();

            foreach (var item in viewModel)
            {
                item.Content = Sanitizer.Sanitize(item.Content);
            }

            return viewModel;
        }

        public DetailedArticleViewModel GetById(int? id)
        {
            var article = this.Data.Articles.GetById(id);
            var viewModel = this.Mapper.Map<DetailedArticleViewModel>(article);

            if (viewModel != null)
            {
                viewModel.Content = Sanitizer.Sanitize(viewModel.Content);
            }

            viewModel.FiveSimilarArticles = this.GetRandomArticles(5, viewModel.CivilizationId).ToList();
            return viewModel;
        }

        public void Create(ContributeArticleViewModel model, string userId)
        {
            var article = Mapper.Map<Article>(model);
            article.CreatorId = userId;
            article.Content = HttpUtility.HtmlDecode(model.Content);

            this.Data.Articles.Add(article);
            this.Data.SaveChanges();
        }

        public ContributeArticleViewModel GetArticleForEditing(int? id)
        {
            return this.Data
                       .Articles
                       .All()
                       .Where(a => a.Id == id)
                       .To<ContributeArticleViewModel>()
                       .FirstOrDefault();
        }

        public void Edit(ContributeArticleViewModel model, string userId)
        {
            var article = this.Data.Articles.GetById(model.Id);
            model.Content = HttpUtility.HtmlDecode(model.Content);
            model.LastEditorId = userId;

            this.Mapper.Map(model, article);
            this.Data.SaveChanges();
        }

        private IQueryable<ArticleViewModel> GetRandomArticles(int count, int civilizationId)
        {
            return this.Data
                       .Articles
                       .All()
                       .Where(a => a.CivilizationId == civilizationId)
                       .OrderBy(x => Guid.NewGuid())
                       .Take(count)
                       .To<ArticleViewModel>();
        }
    }
}
