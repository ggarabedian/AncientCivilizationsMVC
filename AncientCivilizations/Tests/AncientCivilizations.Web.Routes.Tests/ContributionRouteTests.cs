namespace AncientCivilizations.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using Areas.Contribution;
    using Moq;
    using MvcRouteTester;
    using NUnit.Framework;
    using Services.Contracts;

    [TestFixture]
    public class ContributionRouteTests
    {
        private Mock<IArticleServices> articlesServiceMock;
        private Mock<IPictureServices> pictureServicesMock;

        [SetUp]
        public void Setup()
        {
            this.articlesServiceMock = new Mock<IArticleServices>();
            this.pictureServicesMock = new Mock<IPictureServices>();
        }

        [Test]
        public void ContributionAreaArticleCreateRouteShouldBeValid()
        {
            const string Url = "/Contribution/Article/Create/";
            var routeCollection = new RouteCollection();
            var areaRegistration = new ContributionAreaRegistration();

            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routeCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);

            RouteAssert.HasRoute(routeCollection, Url, new { area = "Contribution", controller = "Article", action = "Create", });
        }

        [Test]
        public void ContributionAreaArticleEditRouteShouldBeValid()
        {
            const string Url = "/Contribution/Articles/Edit/5";
            var routeCollection = new RouteCollection();
            var areaRegistration = new ContributionAreaRegistration();

            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routeCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);

            RouteAssert.HasRoute(routeCollection, Url, new { area = "Contribution", controller = "Articles", action = "Edit", id = 5 });
        }
    }
}
