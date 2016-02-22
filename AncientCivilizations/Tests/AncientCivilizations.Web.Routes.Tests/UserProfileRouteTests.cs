namespace AncientCivilizations.Web.Routes.Tests
{
    using System.Web.Routing;

    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    public class UserProfileRouteTests
    {
        [Test]
        public void TestUserProfile()
        {
            const string Url = "/UserProfile/Index/das234-asd123";

            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url)
                           .To<UserProfileController>(x => x.Index("das234-asd123"));
        }
    }
}
