namespace AncientCivilizations.Web.Controllers.Tests
{
    using Areas.Administration.Controllers;
    using Data.Repositories;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AdministratorArticlesControllerTests
    {
        private const string ArticleTitle = "Random Article Title";
        private const string ArticleContent = "Random Article Content";

        private ArticlesController controller;
        private Mock<IAncientCivilizationsData> dataMock;

        [SetUp]
        public void Setup()
        {
            this.dataMock = new Mock<IAncientCivilizationsData>();
        }
    }
}
