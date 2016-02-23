namespace AncientCivilizations.Web.Routes.Tests
{
    using System.Web.Routing;

    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    public class ArticlesRouteTests
    {
        [Test]
        public void TestRouteDetailed()
        {
            const string Url = "/Articles/Detailed/1";

            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url)
                           .To<ArticlesController>(x => x.Detailed(1));
        }

        [Test]
        public void TestRouteAllWithoutFiltration()
        {
            const string Url = "/Articles/All";

            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url)
                           .To<ArticlesController>(x => x.All(null, null, null, null, null, null));
        }

        [Test]
        public void TestRouteAllWithCivilizationFilter()
        {
            const string Url = "/Articles/All?civilizationFilter=5";

            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url)
                           .To<ArticlesController>(x => x.All(null, null, null, null, "5", null));
        }

        [Test]
        public void TestRouteAllWithMultipleFiltrations()
        {
            const string Url = "/Articles/All?civilizationFilter=5&orderBy=Name&page=3";

            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url)
                           .To<ArticlesController>(x => x.All("Name", null, null, 3, "5", null));
        }
    }
}
