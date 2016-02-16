namespace AncientCivilizations.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Base;
    using Contracts;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Public;
    using System.Web;
    using Common.Extensions;

    public class UserProfileServices : BaseServices, IUserProfileServices
    {
        private IAncientCivilizationsData data;

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

        public IEnumerable<ArticleViewModel> GetUsersPendingArticles(string id)
        {
            return this.Data
                       .Articles
                       .All()
                       .Where(a => a.CreatorId == id && !a.IsApproved)
                       .To<ArticleViewModel>()
                       .ToList();
        }

        public IEnumerable<ArticleViewModel> GetUsersApprovedArticleContributions(string id)
        {
            return this.Data
                       .Articles
                       .All()
                       .Where(a => a.CreatorId == id && a.IsApproved)
                       .To<ArticleViewModel>()
                       .ToList();
        }

        public IEnumerable<PicturesViewModel> GetUsersApprovedPictureContributions(string id)
        {
            return this.Data
                       .Pictures
                       .All()
                       .Where(a => a.ContributorId == id)
                       .To<PicturesViewModel>()
                       .ToList();
        }

        public AllContentViewModel GetUsersAllApprovedContributions(string id)
        {
            var allContributions = new AllContentViewModel();
            allContributions.Articles = this.GetUsersApprovedArticleContributions(id);
            allContributions.Pictures = this.GetUsersApprovedPictureContributions(id);

            return allContributions;
        }

        public void UpdateUserProfile(UserProfileViewModel model, IEnumerable<HttpPostedFileBase> images, string id)
        {
            // TODO: Add ModelState validation
            var user = this.Data.Users.GetById(id);
            this.Mapper.Map(model, user);

            if (images != null)
            {
                user.Avatar = ImageEditor.ResizeImageAndConvertToBitArray(images);
            }

            this.Data.Users.SaveChanges();
        }
    }
}
