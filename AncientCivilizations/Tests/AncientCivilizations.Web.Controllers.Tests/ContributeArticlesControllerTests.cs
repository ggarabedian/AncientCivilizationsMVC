namespace AncientCivilizations.Web.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Web;

    using Data.Repositories;
    using Models.Public;
    using Moq;
    using NUnit.Framework;

    public class ContributeArticlesControllerTests
    {
        private const string ArticleTitle = "Random Article Title";
        private const string ArticleContent = "Random Article Content";

        private Mock<IAncientCivilizationsData> dataMock;

        [SetUp]
        public void Setup()
        {
            this.dataMock = new Mock<IAncientCivilizationsData>();
        }

        //[Test]
        //public void AllWithoutParametersShouldRenderCorrectView()
        //{
        //    this.dataMock.Setup(x => x.AllBySearchQuery(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
        //                       .Returns(new List<ArticleViewModel>()
        //                       {
        //                           new ArticleViewModel(),
        //                           new ArticleViewModel(),
        //                       });

        //    this.controller = new ArticlesController(this.articlesServiceMock.Object, this.civilizationsServiceMock.Object);

        //    this.controller.WithCallTo(x => x.All(null, null, null, null, null))
        //                   .ShouldRenderView("All");
        //}
    }
}
