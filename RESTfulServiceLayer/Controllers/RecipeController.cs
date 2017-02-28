using DataAccessLayer;
using DataTransferObjects;
using System.Collections.Generic;
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
            List<RecipeSimplifiedDto> list = dao.GetRecipeList();
            List<RecipeSimplifiedDto> retVal = new List<RecipeSimplifiedDto>();
            foreach (RecipeSimplifiedDto recipe in list)
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
