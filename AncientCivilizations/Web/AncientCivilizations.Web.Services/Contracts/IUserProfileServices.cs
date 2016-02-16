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

        IEnumerable<ArticleViewModel> GetPendingArticles(string id);

        void UpdateUserProfile(UserProfileViewModel model, IEnumerable<HttpPostedFileBase> images, string id);

        IEnumerable<ArticleViewModel> GetApprovedArticleContributions(string id);

        IEnumerable<PicturesViewModel> GetApprovedPictureContributions(string id);

        AllContentViewModel GetAllApprovedContributions(string id);
    }
}
