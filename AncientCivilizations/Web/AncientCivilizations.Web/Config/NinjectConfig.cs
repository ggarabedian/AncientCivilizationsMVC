[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AncientCivilizations.Web.Config.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AncientCivilizations.Web.Config.NinjectConfig), "Stop")]

namespace AncientCivilizations.Web.Config
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Data;
    using Data.Repositories;
    using Services;
    using Services.Contracts;

    public static class NinjectConfig 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            bootstrapper.ShutDown();
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
        }
    }
}
