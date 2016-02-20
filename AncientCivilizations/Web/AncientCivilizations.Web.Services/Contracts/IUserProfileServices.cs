namespace AncientCivilizations.Web.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Data.Models;
    using Models.Public;

    public interface IUserProfileServices
    {
        IQueryable<User> All();

        UserProfileViewModel GetById(string id);

        void UpdateUserProfile(UserProfileViewModel model, IEnumerable<HttpPostedFileBase> images);

        IEnumerable<ArticleViewModel> GetPendingArticles(string id);

        IEnumerable<ArticleViewModel> GetApprovedArticleContributions(string id);

        IEnumerable<PicturesViewModel> GetPictureContributions(string id);
    }
}
