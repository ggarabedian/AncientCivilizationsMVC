namespace AncientCivilizations.Web.Controllers.Tests
{
    using Data.Repositories;
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
        //private Mock<IAncientCivilizationsData> dataMock;

        [SetUp]
        public void Setup()
        {
            //this.dataMock = new Mock<IAncientCivilizationsData>();
            this.articlesServiceMock = new Mock<IArticleServices>();      
            this.civilizationsServiceMock = new Mock<ICivilizationServices>();
        }

        [Test]
        public void DetailedShouldReturnCorrectModel()
        {
            this.articlesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                               .Returns(new DetailedArticleViewModel() { Title = ArticleTitle, Content = ArticleContent });

            this.controller = new ArticlesController(this.articlesServiceMock.Object, this.civilizationsServiceMock.Object);

            this.controller.WithCallTo(x => x.Detailed(5))
                           .ShouldRenderView("Detailed")
                           .WithModel<ArticleViewModel>(
                                viewModel =>
                                {
                                    Assert.AreEqual(ArticleTitle, viewModel.Title);
                                    Assert.AreEqual(ArticleContent, viewModel.Content);
                                }).AndNoModelErrors();
        }

        ////[Test]
        ////public void DetailedShouldThrowOnMissingRequiredTitle()
        ////{
        ////    articlesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
        ////                       .Returns(new ArticleViewModel() { Title = ArticleTitle });

        ////    controller = new ArticlesController(dataMock.Object, articlesServiceMock.Object);

        ////    controller.WithCallTo(x => x.Detailed(5))
        ////              .ShouldRenderView("Detailed")
        ////              .WithModel<ArticleViewModel>(
        ////                    viewModel =>
        ////                    {
        ////                        Assert.AreEqual(ArticleTitle, viewModel.Title);
        ////                    }).AndModelErrorFor(m => m.Content);
        ////}
    }
}
