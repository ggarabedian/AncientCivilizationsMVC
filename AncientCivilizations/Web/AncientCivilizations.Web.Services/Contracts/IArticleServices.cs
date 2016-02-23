namespace AncientCivilizations.Web.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Contribution;
    using Models.Public;

    public interface IArticleServices
    {
        IQueryable<ArticleViewModel> All();

        IEnumerable<ArticleViewModel> AllBySearchQuery(string searchString, string orderBy, string civilizationFilter, string categoryFilter);

        DetailedArticleViewModel GetById(int? id);

        void Create(ContributeArticleViewModel model, string userId);

        void Edit(ContributeArticleViewModel model, string userId);

        ContributeArticleViewModel GetArticleForEditing(int? id);
    }
}
