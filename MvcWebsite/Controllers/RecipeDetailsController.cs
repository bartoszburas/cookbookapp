using DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcWebsiteClient.ViewModels;

namespace MvcWebsiteClient.Controllers
{
    public class RecipeDetailsController : Controller
    {
        HttpClient client;
        string url = "http://cookbookapp.azurewebsites.net/api/recipe";

        // GET: RecipeDetails
        public async Task<ActionResult> Index(int id)
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(url + "/" + id)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var recipeData = JsonConvert.DeserializeObject<RecipeDto>(responseData);
                var recipe = new RecipeDetailsViewModel(recipeData);
                return View(recipe);
            }
            return View();
        }

        public ActionResult AddToShopList()
        {
            return RedirectToAction("Index", "RecipeDetails");
        }
    }
}