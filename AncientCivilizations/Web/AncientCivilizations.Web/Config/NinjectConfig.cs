[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AncientCivilizations.Web.Config.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AncientCivilizations.Web.Config.NinjectConfig), "Stop")]

namespace AncientCivilizations.Web.Config
{
    using System;
    using System.Web;

    using Data;
    using Data.Repositories;
    using Infrastructure.Caching;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Services;
    using Services.Contracts;

    public static class NinjectConfig 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAncientCivilizationsData>().To<AncientCivilizationsData>();
            kernel.Bind<IAncientCivilizationsDbContext>().To<AncientCivilizationsDbContext>();

            kernel.Bind<IUserProfileServices>().To<UserProfileServices>();
            kernel.Bind<IArticleServices>().To<ArticleServices>();
            kernel.Bind<IPictureServices>().To<PictureServices>();
            kernel.Bind<IHomeServices>().To<HomeServices>();
            kernel.Bind<ICivilizationServices>().To<CivilizationServices>();
            kernel.Bind<ICategoryServices>().To<CategoryServices>();
            kernel.Bind<ICacheService>().To<HttpCacheService>();
        }
    }
}
