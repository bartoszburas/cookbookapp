using DataAccessLayer;
using DataTransferObjects;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiServiceLayer.Controllers
{
    public class ShopListController : ApiController
    {
        private IDataAccessObjectFactory daoFactory = DatabaseFactory.GetInstance();

        public ShopListController() { }

        public ShopListController(IDataAccessObjectFactory daoFactory)
        {
            this.daoFactory = daoFactory;
        }

        // GET: api/ShopList/TestUser
        public List<IngredientDto> Get(string userId)
        {
            IDataAccessObject dao = daoFactory.GetDao();
            var result = dao.GetShopList(userId);
            return result;
        }

        // POST: api/ShopList
        [EnableCors(origins: "https://cookbookmvc.azurewebsites.net", headers: "*", methods: "*")]
        public void Post(string userId, [FromBody]IngredientDto ingredient)
        {
            IDataAccessObject dao = daoFactory.GetDao();
            dao.AddShopListItem(userId, ingredient);
        }

        // PUT: api/ShopList/5
        [EnableCors(origins: "https://cookbookmvc.azurewebsites.net", headers: "*", methods: "*")]
        public void Put(string userId, [FromBody]IngredientDto ingredient)
        {
            //IDataAccessObject dao = daoFactory.GetDao();
            //dao.AddShopListItem(userId, ingredient);
        }

        // DELETE: api/ShopList/someId/ingredientName
        [EnableCors(origins: "https://cookbookmvc.azurewebsites.net", headers: "*", methods: "*")]
        public void Delete(string userId, string ingredientName)
        {
            IDataAccessObject dao = daoFactory.GetDao();
            dao.DeleteShopListItem(userId, ingredientName);
        }
    }
}
