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

        IEnumerable<ArticleViewModel> GetUsersPendingArticles(string id);

        void UpdateUserProfile(UserProfileViewModel model, IEnumerable<HttpPostedFileBase> images, string id);

        IEnumerable<ArticleViewModel> GetUsersApprovedArticleContributions(string id);

        IEnumerable<PicturesViewModel> GetUsersApprovedPictureContributions(string id);

        AllContentViewModel GetUsersAllApprovedContributions(string id);
    }
}
