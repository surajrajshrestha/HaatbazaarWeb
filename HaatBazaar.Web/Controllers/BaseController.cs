using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HaatBazaar.Web.Controllers
{
    public class BaseController : Controller
    {
        public string ApiUrl { get; }
        
        public BaseController(IConfiguration configuration, string url)
        {
            var baseUrl = configuration["HaatBazaarApi:BaseUrl"]!;
            ApiUrl = $"{baseUrl}/api/{url}";
        }

        public async Task<List<T>> GetAllAsync<T>()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ApiUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<List<T>>(responseString);
            return responseObject ?? [];
        }

        public async Task<T?> GetByIdAsync<T>(int? id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{ApiUrl}/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);
            return responseObject;
        }
        public async Task<T?> GetByIdAsync<T>(long? id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{ApiUrl}/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);
            return responseObject;
        }

        public async Task PostAsync<T>(T model)
        {
            var client = new HttpClient();
            await client.PostAsJsonAsync(ApiUrl, model);
        }

        public async Task<object> PostAsync<T>(T model, string endpoint)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync($"{ApiUrl}/{endpoint}", model);
            return response;
        }

        public async Task PutAsync<T>(int id, T model)
        {
            var client = new HttpClient();
            await client.PutAsJsonAsync($"{ApiUrl}/{id}", model);
        }
        public async Task PutAsync<T>(long id, T model)
        {
            var client = new HttpClient();
            await client.PutAsJsonAsync($"{ApiUrl}/{id}", model);
        }

        public async Task DeleteAsync<T>(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{ApiUrl}/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);

            if (responseObject != null)
            {
                await client.DeleteAsync($"{ApiUrl}/{id}");
            }
        }
        public async Task DeleteAsync<T>(long id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{ApiUrl}/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);

            if (responseObject != null)
            {
                await client.DeleteAsync($"{ApiUrl}/{id}");
            }
        }
    }
}
