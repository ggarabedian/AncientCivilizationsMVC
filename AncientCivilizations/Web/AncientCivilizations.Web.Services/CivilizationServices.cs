namespace AncientCivilizations.Web.Services
{
    using System.Linq;

    using Base;
    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Administration;
    using Services.Contracts;

    public class CivilizationServices : BaseServices, ICivilizationServices
    {
        public CivilizationServices(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public IQueryable<CivilizationViewModel> All()
        {
            return this.Data.Civilizations.All().To<CivilizationViewModel>();
        }
    }
}
