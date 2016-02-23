namespace AncientCivilizations.Web.Services
{
    using System.Linq;

    using Base;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Public;
    using Services.Contracts;

    public class CategoryServices : BaseServices, ICategoryServices
    {
        public CategoryServices(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public IQueryable<CategoryViewModel> All()
        {
            return this.Data.Categories.All().To<CategoryViewModel>();
        }
    }
}
