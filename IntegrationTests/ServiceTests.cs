using DataTransferObjects;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    [TestFixture]
    class ServiceTests
    {
        [Test]
        public async Task GetRecipeListServiceTest()
        {
            const string url = "http://cookbookapp.azurewebsites.net/api/recipe";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = await client.GetAsync(url);

            if (!message.IsSuccessStatusCode)
                Assert.Fail();
        }

        [Test]
        public async Task GetRecipeServiceTest()
        {
            // Arrange 
            const string urlList = "http://cookbookapp.azurewebsites.net/api/recipe";
            const string url = "http://cookbookapp.azurewebsites.net/api/recipe/";
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(urlList)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = await client.GetAsync(urlList);
            var responseData = message.Content.ReadAsStringAsync().Result;
            var recipesData = JsonConvert.DeserializeObject<List<RecipeSimplifiedDto>>(responseData);

            HttpClient client2 = new HttpClient();
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client2.BaseAddress = new Uri(url + recipesData[0].IdRecipe);

            // Act 
            message = await client2.GetAsync(url + recipesData[0].IdRecipe);

            // Assert
            if (!message.IsSuccessStatusCode)
                Assert.Fail();
        }

        [Test]
        public async Task AddShoplistTest()
        {
            // Arrange 
            const string url = "https://cookbookapp.azurewebsites.net/api/Shoplist/db1500c7-f616-45d3-8069-14a9f264f2fa/Add";
            HttpClient client = new HttpClient() { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add( 
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var addedItem = new IngredientDto() { IngredientName = "Test", Amount = 0 };
            var jsonObject = JsonConvert.SerializeObject(addedItem);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            // Act
            HttpResponseMessage message = await client.PostAsync(url, content);
            
            // Assert
            if (!message.IsSuccessStatusCode)
                Assert.Fail();

            // Cleanup
            const string toDeleteUrl = "https://cookbookapp.azurewebsites.net/api/Shoplist/db1500c7-f616-45d3-8069-14a9f264f2fa/Test";
            HttpClient clientDeleting = new HttpClient() { BaseAddress = new Uri(toDeleteUrl) };
            clientDeleting.DefaultRequestHeaders.Accept.Clear();
            clientDeleting.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var deleteMessage = await clientDeleting.DeleteAsync(toDeleteUrl);

            if (!deleteMessage.IsSuccessStatusCode)
                throw new Exception("Cleanup failed. Need to manually delete test record from database");
        }
    }
}
