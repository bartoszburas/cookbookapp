using NUnit.Framework;
using System;
using System.Net.Http;
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
            //HttpClientHandler handler = new HttpClientHandler()
            //{
            //    Credentials = 
            //}
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = await client.GetAsync(url);

            if (!message.IsSuccessStatusCode)
                Assert.Fail();
        }

        [Test]
        public async Task GetRecipeServiceTest()
        {
            const string url = "http://cookbookapp.azurewebsites.net/api/recipe/1";
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = await client.GetAsync(url);

            if (!message.IsSuccessStatusCode)
                Assert.Fail();
        }
    }
}
