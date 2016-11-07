using System;
using System.Collections.Generic;
using DataTransferObjects;
using DataAccessLayer;

namespace ServiceLayer
{
    public class Service : IService
    {
        IDataAccessObjectFactory daoFactory = DatabaseFactory.GetInstance();

        public RecipeDto GetRecipe(int id)
        {
            IDataAccessObject dao = daoFactory.GetDao();
            return new RecipeDto() { adaptee = dao.GetRecipe(id) };
        }

        public List<RecipeSimplifiedDto> GetRecipeList()
        {
            IDataAccessObject dao = daoFactory.GetDao();
            List<DataTransferObjects.RecipeSimplifiedDto> list = dao.GetRecipeList();
            List<RecipeSimplifiedDto> retVal = new List<RecipeSimplifiedDto>();
            foreach (DataTransferObjects.RecipeSimplifiedDto recipe in list)
                retVal.Add(new RecipeSimplifiedDto() { adaptee = recipe });
            return retVal;
        }

        public void AddRecipe(RecipeDto recipe)
        {
            IDataAccessObject dao = daoFactory.GetDao();
            dao.AddRecipe(recipe.adaptee);    
        }
    }
}
