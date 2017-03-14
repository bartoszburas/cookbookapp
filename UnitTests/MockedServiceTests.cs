using NUnit.Framework;
using WebApiService.Controllers;
using WebApiServiceLayer.Controllers;

namespace UnitTests
{
    [TestFixture]
    public class MockedServiceTests
    {
        [Test]
        public void GetRecipesMockedTest()
        {
            // Arrange
            var service = new RecipeController(new MockedDatabaseFactory());
            var mock = new MockedDatabaseFactory();
            service.Request = new System.Net.Http.HttpRequestMessage();
            service.Configuration = new System.Web.Http.HttpConfiguration();

            // Act
            var result = service.Get();

            // Assert
            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void GetShopListMockedTest()
        {
            // Arrange
            var service = new ShopListController(new MockedDatabaseFactory());
            var mock = new MockedDatabaseFactory();
            service.Request = new System.Net.Http.HttpRequestMessage();
            service.Configuration = new System.Web.Http.HttpConfiguration();

            // Act
            var result = service.Get("testUser");

            // Assert
            Assert.AreEqual(result.Count, 4);
        }
    }
}
