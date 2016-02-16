namespace AncientCivilizations.Web.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Models;
    using Models.Contribution;
    using Models.Public;

    public interface IPictureServices
    {
        IQueryable<Picture> All();

        IEnumerable<ContributePictureViewModel> AllBySearchQuery(string searchQuery);

        PicturesViewModel GetById(int id);
    }
}
