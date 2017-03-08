using System.Collections.Generic;
using DataTransferObjects;

namespace DataAccessLayer
{
    public interface IDataAccessObject
    {
        List<RecipeSimplifiedDto> GetRecipeList();                                                                           
        RecipeDto GetRecipe(int id);
        void AddRecipe(RecipeDto recipe);
        void DeleteRecipe(string name);
        List<IngredientDto> GetShopList(string userId);
        void AddShopListItem(string userId, IngredientDto ingredient);
        void DeleteShopListItem(string userId, string ingredientName);
    }
}
