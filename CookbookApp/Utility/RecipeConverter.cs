using CookbookApp.ServiceReference;
using System.Collections.Generic;

namespace CookbookApp
{
    class RecipeConverter
    {
        public static List<Recipe> ConvertRecipeList(RecipeSimplifiedDto[] list)
        {
            List<Recipe> newList = new List<Recipe>();
            foreach (var recipe in list)
            {
                Recipe r = new Recipe()
                {
                    IdRecipe = recipe.IdRecipe,
                    Name = recipe.Name,
                    Picture = ImageConverter.ByteArrayToImage(recipe.Picture)
                };

                newList.Add(r);
            }

            return newList;
        }

        public static Recipe ConvertRecipe(RecipeDto recipe)
        {
            Recipe retVal = new Recipe()
            {
                Amount = recipe.Amount,
                IdRecipe = recipe.IdRecipe,
                Ingredients = recipe.RecipeIngredient,
                Name = recipe.Name,
                Picture = ImageConverter.ByteArrayToImage(recipe.Picture),
                Preparation = recipe.PreparationDescription,
                PreparationTime = recipe.PreparationTime,
                SkillLevel = recipe.SkillLevel
            };

            return retVal;
        }
    }
}
