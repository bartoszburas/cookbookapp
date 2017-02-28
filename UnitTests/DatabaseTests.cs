using DataAccessLayer;
using DataTransferObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    /// <summary>
    ///     Database tests change the state of database. These are not tests with mocked data! 
    /// </summary>
    [TestFixture]
    public class DatabaseTests
    {

        [Test]
        public void AddRecipeTest()
        {
            Database database = new Database();
            RecipeDto newRecipe = new RecipeDto()
            {
                Amount = 2,
                Name = "Test",
                PreparationDescription = "DescriptionTest",
                PreparationTime = new TimeSpan(0, 20, 0),
                SkillLevel = "Begginer",
                Ingredients = new List<IngredientDto>()
                {
                    new IngredientDto() { Amount = 2, IngredientName = "IngredientTest", Unit = "UnitTest"},
                    new IngredientDto() { Amount = 2, IngredientName = "IngredientTest2", Unit = "UnitTest"}
                }
            };
            database.AddRecipe(newRecipe);
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                    return;
            Assert.Fail();
        }

        [Test]
        public void DeleteRecipeTest()
        {
            Database database = new Database();
            database.DeleteRecipe("Test");
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                    Assert.Fail();
        }

        [Test]
        public void GetRecipeTest()
        {
            Database database = new Database();
            var r = database.GetRecipe(1);
            if (r.Ingredients == null)
                Assert.Fail();
        }

        [Test]
        public void GetRecipeListTest()
        {
            var database = new Database();
            var l = database.GetRecipeList();
            if (l == null)
                Assert.Fail();
        }
    }
}