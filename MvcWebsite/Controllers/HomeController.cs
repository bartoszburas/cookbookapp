using DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcWebsiteClient.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;
        string url = "http://cookbookapp.azurewebsites.net/api/recipe";

        [RequireHttps]
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var recipesData = JsonConvert.DeserializeObject<List<RecipeSimplifiedDto>>(responseData);
                var recipes = new ViewModels.RecipeListViewModel();
                foreach (var r in recipesData)
                    recipes.list.Add(r);
                return View(recipes);
            }
            return View();
        }
    }
}
