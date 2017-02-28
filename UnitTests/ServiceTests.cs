using NUnit.Framework;
using Moq;
using DataAccessLayer;
using DataTransferObjects;
using System.Collections.Generic;

namespace UnitTests
{
    // TODO: to nie ma sensu, testowanie tego czego nauczylismy mocka,
    // ale sie przyda przy testowaniu klienta
    [TestFixture]
    public class ServiceTests
    {
        Mock<IDataAccessObject> mockedDatabase;

        RecipeDto sampleRecipe = new RecipeDto()
        {
            Amount = 1,
            IdRecipe = 1,
            Ingredients = new List<IngredientDto>()
                {
                    new IngredientDto()
                    {
                        Amount = 2,
                        IngredientName = "Test4",
                        Unit = "Test5"
                    }
                },
            Name = "Test6",
            PreparationDescription = "Test7",
            PreparationTime = new System.TimeSpan(),
            SkillLevel = "begginer"
        };

        List<RecipeSimplifiedDto> sampleList = new List<RecipeSimplifiedDto>()
        {
            new RecipeSimplifiedDto()
            {
                IdRecipe = 1,
                Name = "test1"
            },
            new RecipeSimplifiedDto()
            {
                IdRecipe = 2,
                Name = "test2"
            },
            new RecipeSimplifiedDto()
            {
                IdRecipe = 3,
                Name = "test3"
            },
        };

        [Test]
        public void AddRecipeMockedTest()
        {
            // Arrange
            mockedDatabase = new Mock<IDataAccessObject>();

            mockedDatabase.Setup(x => x.GetRecipeList()).Returns(sampleList);
            mockedDatabase.Setup(x => x.GetRecipe(1)).Returns(sampleRecipe);
            mockedDatabase.Setup(x => x.AddRecipe(sampleRecipe))
                .Callback<RecipeDto>(x => sampleList.Add(new RecipeSimplifiedDto()
                {
                    IdRecipe = sampleRecipe.IdRecipe,
                    Name = sampleRecipe.Name,
                    Picture = sampleRecipe.Picture
                }));

            var listCopy = new List<RecipeSimplifiedDto>(sampleList);
            listCopy.Add(new RecipeSimplifiedDto()
            {
                IdRecipe = sampleRecipe.IdRecipe,
                Name = sampleRecipe.Name,
                Picture = sampleRecipe.Picture
            });

            // Act
            mockedDatabase.Object.AddRecipe(sampleRecipe);
            var returned = mockedDatabase.Object.GetRecipeList();

            // Assert
            Assert.AreEqual(returned[3].IdRecipe, listCopy[3].IdRecipe);
            Assert.AreEqual(returned[3].Name, listCopy[3].Name);
            Assert.AreEqual(returned[3].Picture, listCopy[3].Picture);
        }
    }
}
