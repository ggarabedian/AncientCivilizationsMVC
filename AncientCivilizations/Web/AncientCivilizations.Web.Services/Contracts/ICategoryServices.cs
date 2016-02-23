namespace AncientCivilizations.Web.Services.Contracts
{
    using System.Linq;

    using Models.Public;

    public interface ICategoryServices
    {
        IQueryable<CategoryViewModel> All();
    }
}
