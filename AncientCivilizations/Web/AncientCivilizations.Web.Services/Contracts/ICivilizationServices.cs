namespace AncientCivilizations.Web.Services.Contracts
{
    using System.Linq;

    using Data.Models;

    public interface ICivilizationServices
    {
        IQueryable<Civilization> All();
    }
}
