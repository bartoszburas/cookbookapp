using DataAccessLayer;
using DataTransferObjects;
using System.Collections.Generic;
using System;
using Moq;

namespace UnitTests
{
    class MockedDatabaseFactory : IDataAccessObjectFactory
    {
        public string GetConnectionString()
        {
            return "Mock";
        }

        public IDataAccessObject GetDao()
        {
            var mockedDatabase = new Mock<IDataAccessObject>(); ;

            SetupMock(mockedDatabase);

            return (IDataAccessObject)mockedDatabase;
        }

        private void SetupMock(Mock<IDataAccessObject> mockedDatabase)
        {
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


            mockedDatabase.Setup(x => x.GetRecipeList()).Returns(sampleList);
            mockedDatabase.Setup(x => x.GetRecipe(1)).Returns(sampleRecipe);
            mockedDatabase.Setup(x => x.AddRecipe(sampleRecipe))
                .Callback<RecipeDto>(x => sampleList.Add(new RecipeSimplifiedDto()
                {
                    IdRecipe = sampleRecipe.IdRecipe,
                    Name = sampleRecipe.Name,
                    Picture = sampleRecipe.Picture
                }));
        }
    }
}
