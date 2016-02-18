namespace AncientCivilizations.Web.Controllers.Tests
{
    using Moq;
    using NUnit.Framework;
    using TestStack.FluentMVCTesting;

    using Data.Repositories;
    using Models.Public;
    using Services.Contracts;

    [TestFixture]
    public class PublicArtcilesControllerTests
    {
        const string ArticleTitle = "Random Article Title";
        const string ArticleContent = "Random Article Content";

        private ArticlesController controller;
        private Mock<IArticleServices> articlesServiceMock;
        private Mock<IAncientCivilizationsData> dataMock;

        [SetUp]
        public void Setup()
        {
            dataMock = new Mock<IAncientCivilizationsData>();
            articlesServiceMock = new Mock<IArticleServices>();           
        }

        [Test]
        public void DetailedShouldReturnCorrectModel()
        {
            articlesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                               .Returns(new ArticleViewModel() { Title = ArticleTitle, Content = ArticleContent });

            controller = new ArticlesController(dataMock.Object, articlesServiceMock.Object);

            controller.WithCallTo(x => x.Detailed(5))
                      .ShouldRenderView("Detailed")
                      .WithModel<ArticleViewModel>(
                            viewModel =>
                            {
                                Assert.AreEqual(ArticleTitle, viewModel.Title);
                                Assert.AreEqual(ArticleContent, viewModel.Content);
                            }).AndNoModelErrors();
        }

        //[Test]
        //public void DetailedShouldThrowOnMissingRequiredTitle()
        //{
        //    articlesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
        //                       .Returns(new ArticleViewModel() { Title = ArticleTitle });

        //    controller = new ArticlesController(dataMock.Object, articlesServiceMock.Object);

        //    controller.WithCallTo(x => x.Detailed(5))
        //              .ShouldRenderView("Detailed")
        //              .WithModel<ArticleViewModel>(
        //                    viewModel =>
        //                    {
        //                        Assert.AreEqual(ArticleTitle, viewModel.Title);
        //                    }).AndModelErrorFor(m => m.Content);
        //}
    }
}
