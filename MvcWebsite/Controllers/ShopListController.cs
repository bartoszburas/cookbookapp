using DataTransferObjects;
using Microsoft.AspNet.Identity;
using MvcWebsite.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcWebsite.Controllers
{
    public class ShopListController : Controller
    {
        HttpClient client;
        string url = "http://cookbookapp.azurewebsites.net/api/shoplist";

        // GET: ShopList
        [Authorize]
        public async Task<ActionResult> Index()
        {
            string userId = User.Identity.GetUserId();
            client = new HttpClient()
            {
                BaseAddress = new System.Uri(url + "/" + userId)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = await client.GetAsync(url + "/" + userId);
            var id = User.Identity.GetUserId<string>();
            if(message.IsSuccessStatusCode)
            {
                var responseData = message.Content.ReadAsStringAsync().Result;
                var shopListData = JsonConvert.DeserializeObject<List<IngredientDto>>(responseData);

                var shopList = new ShopListViewModel()
                {
                    list = shopListData
                };

                return View(shopList);
            }
            return View();
        }
    }
}