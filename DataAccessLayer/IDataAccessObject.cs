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
        List<IngredientDto> GetShopList(string userName);
    }
}
