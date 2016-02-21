namespace AncientCivilizations.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using Areas.Administration;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class AdministrationRouteTests
    {
        [Test]
        public void AdministrationAreaHomeIndexRouteShouldBeValid()
        {
            const string Url = "/Administration/Home/Index/";
            var routeCollection = new RouteCollection();
            var areaRegistration = new AdministrationAreaRegistration();

            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routeCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);

            RouteAssert.HasRoute(routeCollection, Url, new { area = "Administration", controller = "Home", action = "Index", });
        }

        [Test]
        public void AdministrationAreaArticlesIndexRouteShouldBeValid()
        {
            const string Url = "/Administration/Articles/Index/";
            var routeCollection = new RouteCollection();
            var areaRegistration = new AdministrationAreaRegistration();

            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routeCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);

            RouteAssert.HasRoute(routeCollection, Url, new { area = "Administration", controller = "Articles", action = "Index", });
        }
    }
}
