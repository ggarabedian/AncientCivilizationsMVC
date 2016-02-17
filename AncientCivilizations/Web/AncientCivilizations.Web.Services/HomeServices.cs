namespace AncientCivilizations.Web.Services
{
    using System.Linq;

    using Base;
    using Contracts;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Public;

    public class HomeServices : BaseServices, IHomeServices
    {
        public HomeServices(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public AllContentViewModel GetHomePageData()
        {
            var articles = this.Data.Articles
                                    .All()
                                    .Where(ar => ar.IsApproved)
                                    .OrderByDescending(a => a.CreatedOn)
                                    .Take(5)
                                    .To<ArticleViewModel>()
                                    .ToList();

            var pictures = this.Data.Pictures
                                    .All()
                                    .OrderByDescending(p => p.CreatedOn)
                                    .Take(5)
                                    .To<PicturesViewModel>()
                                    .ToList();

            return new AllContentViewModel() { Articles = articles, Pictures = pictures };
        }
    }
}
