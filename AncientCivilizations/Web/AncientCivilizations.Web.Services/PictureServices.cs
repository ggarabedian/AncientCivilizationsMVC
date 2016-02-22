namespace AncientCivilizations.Web.Services
{
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

    public class PictureServices : BaseServices, IPictureServices
    {
        public PictureServices(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public IQueryable<PicturesViewModel> All()
        {
            return this.Data.Pictures.All().To<PicturesViewModel>();
        }

        public IEnumerable<ContributePictureViewModel> AllBySearchQueryToAddToArticle(string searchQuery, int take = 40)
        {
            var viewModel = this.GetAllBySearchQuery(searchQuery, take)
                                .To<ContributePictureViewModel>()
                                .ToList();
            return viewModel;
        }

        public void Add(ContributePictureViewModel model, IEnumerable<HttpPostedFileBase> images, string userId)
        {
            // TODO: Add ModelState validation
            model.Url = ImageEditor.SaveImageToServer(images, userId);
            model.ContributorId = userId;
            var picture = Mapper.Map<Picture>(model);

            this.Data.Pictures.Add(picture);
            this.Data.SaveChanges();
        }

        public IEnumerable<PicturesViewModel> AllBySearchQuery(string searchQuery, int take = 40)
        {
            var viewModel = this.GetAllBySearchQuery(searchQuery, take)
                                .To<PicturesViewModel>()
                                .ToList();
            return viewModel;
        }

        public PicturesViewModel GetById(int? id)
        {
            var picture = this.Data.Pictures.GetById(id);
            var viewModel = this.Mapper.Map<PicturesViewModel>(picture);
            return viewModel;
        }

        private IQueryable<Picture> GetAllBySearchQuery(string searchQuery, int take)
        {
            var pictures = this.Data.Pictures.All().Take(take);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                pictures = pictures.Where(p => p.Title.Contains(searchQuery) || p.KeyWords.Contains(searchQuery));
            }

            return pictures;
        }
    }
}
