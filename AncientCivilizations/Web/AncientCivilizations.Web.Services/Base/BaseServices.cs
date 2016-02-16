namespace AncientCivilizations.Web.Services.Base
{
    using AutoMapper;

    using Data.Repositories;
    using Infrastructure.Mapping;

    public abstract class BaseServices
    {
        protected IAncientCivilizationsData Data { get; private set; }

        public BaseServices(IAncientCivilizationsData data)
        {
            this.Data = data;
        }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
