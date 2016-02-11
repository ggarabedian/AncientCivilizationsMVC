namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Data.Repositories;
    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        public BaseController(IAncientCivilizationsData data)
        {
            this.Data = data;
        }

        protected IAncientCivilizationsData Data { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}