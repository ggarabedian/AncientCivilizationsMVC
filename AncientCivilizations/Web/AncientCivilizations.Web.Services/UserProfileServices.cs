namespace AncientCivilizations.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Base;
    using Common.Extensions;
    using Contracts;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Public;
    using System.Web;

    public class UserProfileServices : BaseServices, IUserProfileServices
    {
        public UserProfileServices(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public IQueryable<User> All()
        {
            return this.Data.Users.All();

        }

        public UserProfileViewModel GetById(string id)
        {
            var user = this.Data.Users.GetById(id);
            var viewModel = this.Mapper.Map<UserProfileViewModel>(user);

            return viewModel;
        }

        public IEnumerable<ArticleViewModel> GetPendingArticles(string id)
        {
            return this.Data
                       .Articles
                       .All()
                       .Where(a => a.CreatorId == id && !a.IsApproved)
                       .To<ArticleViewModel>()
                       .ToList();
        }

        public IEnumerable<ArticleViewModel> GetApprovedArticleContributions(string id)
        {
            return this.Data
                       .Articles
                       .All()
                       .Where(a => a.CreatorId == id && a.IsApproved)
                       .To<ArticleViewModel>()
                       .ToList();
        }

        public IEnumerable<PicturesViewModel> GetApprovedPictureContributions(string id)
        {
            return this.Data
                       .Pictures
                       .All()
                       .Where(a => a.ContributorId == id)
                       .To<PicturesViewModel>()
                       .ToList();
        }

        public AllContentViewModel GetAllApprovedContributions(string id)
        {
            var allContributions = new AllContentViewModel();
            allContributions.Articles = this.GetApprovedArticleContributions(id);
            allContributions.Pictures = this.GetApprovedPictureContributions(id);

            return allContributions;
        }

        public void UpdateUserProfile(UserProfileViewModel model, IEnumerable<HttpPostedFileBase> images)
        {
            // TODO: Add ModelState validation
            var user = this.Data.Users.GetById(model.Id);
            this.Mapper.Map(model, user);

            if (images != null)
            {
                user.Avatar = ImageEditor.ResizeImageAndConvertToBitArray(images);
            }

            this.Data.Users.SaveChanges();
        }
    }
}
