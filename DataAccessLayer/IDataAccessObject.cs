using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessLayer
{
    public interface IDataAccessObject
    {
        List<RecipeSimplifiedDto> GetRecipeList();                                                                           
        RecipeDto GetRecipe(int id);
        void AddRecipe(RecipeDto recipe);
        void DeleteRecipe(string name);
    }
}
