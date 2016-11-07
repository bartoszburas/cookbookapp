using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessLayer.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        [TestMethod()]
        public void AddRecipeTest()
        {
            Database database = new Database();
            RecipeDto newRecipe = new RecipeDto()
            {
                Amount = 2, Name = "Test", PreparationDescription = "DescriptionTest",
                PreparationTime = new TimeSpan(0, 20, 0), SkillLevel = "Begginer",
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

        [TestMethod()]
        public void DeleteRecipeTest()
        {
            Database database = new Database();
            database.DeleteRecipe("Test");
            List<RecipeSimplifiedDto> list = database.GetRecipeList();
            foreach (RecipeSimplifiedDto r in list)
                if (r.Name == "Test")
                    Assert.Fail();
        }
         
        [TestMethod()]
        public void GetRecipeTest()
        {
            Database database = new Database();
            var r = database.GetRecipe(1);
            if(r.Ingredients == null)
                Assert.Fail();
        }

        [TestMethod()]
        public void GetRecipeListTest()
        {
            Assert.Fail();
        }
    }
}