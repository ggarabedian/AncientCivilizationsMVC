namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Data.Repositories;
    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}