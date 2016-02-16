namespace AncientCivilizations.Web.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Data.Models;
    using Models.Contribution;
    using Models.Public;

    public interface IPictureServices
    {
        IQueryable<Picture> All();

        IEnumerable<ContributePictureViewModel> AllBySearchQueryToAddToArticle(string searchQuery, int take = 50);

        void Add(ContributePictureViewModel model, IEnumerable<HttpPostedFileBase> images, string userId);

        IEnumerable<PicturesViewModel> AllBySearchQuery(string searchQuery, int take = 50);

        PicturesViewModel GetById(int? id);
    }
}
