namespace AncientCivilizations.Web.Services.Base
{
    using AutoMapper;

    using Data.Repositories;
    using Infrastructure.Mapping;

    public abstract class BaseServices
    {
        public BaseServices(IAncientCivilizationsData data)
        {
            this.Data = data;
        }

        protected IAncientCivilizationsData Data { get; private set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
