using DataAccessLayer;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTfulServiceLayer.Controllers
{
    public class RecipeController : ApiController
    {
        IDataAccessObjectFactory daoFactory = DatabaseFactory.GetInstance();

        public RecipeDto Get(int id)
        {
            IDataAccessObject dao = daoFactory.GetDao();
            return dao.GetRecipe(id);
        }

        public List<RecipeSimplifiedDto> Get()
        {
            IDataAccessObject dao = daoFactory.GetDao();
            List<DataTransferObjects.RecipeSimplifiedDto> list = dao.GetRecipeList();
            List<RecipeSimplifiedDto> retVal = new List<RecipeSimplifiedDto>();
            foreach (DataTransferObjects.RecipeSimplifiedDto recipe in list)
                retVal.Add(recipe);
            return retVal;
        }

        public void Post(RecipeDto recipe)
        {
            IDataAccessObject dao = daoFactory.GetDao();
            dao.AddRecipe(recipe);
        }
    }
}
