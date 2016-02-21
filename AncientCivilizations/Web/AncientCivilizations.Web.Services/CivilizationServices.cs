namespace AncientCivilizations.Web.Services
{
    using System.Linq;

    using Base;
    using Data.Models;
    using Data.Repositories;
    using Services.Contracts;

    public class CivilizationServices : BaseServices, ICivilizationServices
    {
        public CivilizationServices(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public IQueryable<Civilization> All()
        {
            return this.Data.Civilizations.All();
        }
    }
}
