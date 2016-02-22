namespace AncientCivilizations.Web.Services.Contracts
{
    using System.Linq;

    using Models.Administration;

    public interface ICivilizationServices
    {
        IQueryable<CivilizationViewModel> All();
    }
}
