namespace AncientCivilizations.Web.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Web;

    using Models.Public;
    using Moq;
    using NUnit.Framework;
    using Services.Contracts;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class PublicArtcilesControllerTests
    {
        private const string ArticleTitle = "Random Article Title";
        private const string ArticleContent = "Random Article Content";

        private ArticlesController controller;
        private Mock<IArticleServices> articlesServiceMock;
        private Mock<ICivilizationServices> civilizationsServiceMock;

        [SetUp]
        public void Setup()
        {
            this.articlesServiceMock = new Mock<IArticleServices>();
            this.civilizationsServiceMock = new Mock<ICivilizationServices>();
        }

        [Test]
        public void AllWithoutParametersShouldRenderCorrectView()
        {
            this.articlesServiceMock.Setup(x => x.AllBySearchQuery(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                               .Returns(new List<ArticleViewModel>()
                               {
                                   new ArticleViewModel(),
                                   new ArticleViewModel(),
                               });

            this.controller = new ArticlesController(this.articlesServiceMock.Object, this.civilizationsServiceMock.Object);

            this.controller.WithCallTo(x => x.All(null, null, null, null, null))
                           .ShouldRenderView("All");
        }

        [Test]
        public void DetailedShouldRenderCorrectView()
        {
            this.articlesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                               .Returns(new DetailedArticleViewModel()
                               {
                                   Title = ArticleTitle,
                                   Content = ArticleContent
                               });

            this.controller = new ArticlesController(this.articlesServiceMock.Object, this.civilizationsServiceMock.Object);

            this.controller.WithCallTo(x => x.Detailed(5))
                           .ShouldRenderView("Detailed");
        }

        [Test]
        public void DetailedShouldReturnCorrectModel()
        {
            this.articlesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                               .Returns(new DetailedArticleViewModel()
                               {
                                   Title = ArticleTitle,
                                   Content = ArticleContent
                               });

            this.controller = new ArticlesController(this.articlesServiceMock.Object, this.civilizationsServiceMock.Object);

            this.controller.WithCallTo(x => x.Detailed(5))
                           .ShouldRenderView("Detailed")
                           .WithModel<DetailedArticleViewModel>(
                                viewModel =>
                                {
                                    Assert.AreEqual(ArticleTitle, viewModel.Title);
                                    Assert.AreEqual(ArticleContent, viewModel.Content);
                                }).AndNoModelErrors();
        }

        [Test]
        public void DetailShouldThrowWhenIdIsNull()
        {
            this.articlesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                               .Returns(new DetailedArticleViewModel()
                               {
                                   Title = ArticleTitle,
                                   Content = ArticleContent
                               });

            this.controller = new ArticlesController(this.articlesServiceMock.Object, this.civilizationsServiceMock.Object);

            var ex = Assert.Throws<HttpException>(() => this.controller.WithCallTo(x => x.Detailed(null)));
            Assert.IsTrue(ex.Message.Contains("Detailed article requires id"));
        }

        [Test]
        public void DetailShoudThrowWhenArticleWithSuchIdDoesNotExist()
        {
            this.articlesServiceMock.Setup(x => x.GetById(5))
                               .Returns(new DetailedArticleViewModel()
                               {
                                   Title = ArticleTitle,
                                   Content = ArticleContent
                               });

            this.controller = new ArticlesController(this.articlesServiceMock.Object, this.civilizationsServiceMock.Object);

            var ex = Assert.Throws<HttpException>(() => this.controller.WithCallTo(x => x.Detailed(6)));
            Assert.IsTrue(ex.Message.Contains("No such article exists in the database"));
        }
    }
}
