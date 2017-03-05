using NUnit.Framework;

namespace UnitTests
{

    // TODO: cache zmockowanego serwisu
    [TestFixture]
    public class CacheTests
    {
        [Test]
        public void AddRecipeMockedTest()
        {
            //// Arrange
            //mockedDatabase = new Mock<IDataAccessObject>();

            //mockedDatabase.Setup(x => x.GetRecipeList()).Returns(sampleList);
            //mockedDatabase.Setup(x => x.GetRecipe(1)).Returns(sampleRecipe);
            //mockedDatabase.Setup(x => x.AddRecipe(sampleRecipe))
            //    .Callback<RecipeDto>(x => sampleList.Add(new RecipeSimplifiedDto()
            //    {
            //        IdRecipe = sampleRecipe.IdRecipe,
            //        Name = sampleRecipe.Name,
            //        Picture = sampleRecipe.Picture
            //    }));

            //var listCopy = new List<RecipeSimplifiedDto>(sampleList)
            //{
            //    new RecipeSimplifiedDto()
            //    {
            //        IdRecipe = sampleRecipe.IdRecipe,
            //        Name = sampleRecipe.Name,
            //        Picture = sampleRecipe.Picture
            //    }
            //};

            //// Act
            //mockedDatabase.Object.AddRecipe(sampleRecipe);
            //var returned = mockedDatabase.Object.GetRecipeList();

            //// Assert
            //Assert.AreEqual(returned[3].IdRecipe, listCopy[3].IdRecipe);
            //Assert.AreEqual(returned[3].Name, listCopy[3].Name);
            //Assert.AreEqual(returned[3].Picture, listCopy[3].Picture);
        }
    }
}
