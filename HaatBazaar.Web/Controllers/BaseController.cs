using System.Net.Http.Headers;
using HaatBazaar.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HaatBazaar.Web.Controllers
{
    public class BaseController : Controller
    {
        public string ApiUrl { get; }

        private string _token;

        public BaseController(IConfiguration configuration)
        {
            var baseUrl = configuration["HaatBazaarApi:BaseUrl"]!;
            ApiUrl = $"{baseUrl}/api";
        }

        public async Task<List<T>> GetAllAsync<T>(string url)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync($"{ApiUrl}/{url}");

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<List<T>>(responseString);
            return responseObject ?? [];
        }

        public async Task<T?> GetByIdAsync<T>(string url, int? id)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync($"{ApiUrl}/{url}/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);
            return responseObject;
        }
        public async Task<T?> GetByIdAsync<T>(string url, long? id)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync($"{ApiUrl}/{url}/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);
            return responseObject;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T model)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.PostAsJsonAsync($"{ApiUrl}/{url}", model);
            return response;
        }

        //public async Task<HttpResponseMessage> PostAsync<T>(T model, string endpoint)
        //{
        //    _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    var response = await client.PostAsJsonAsync($"{ApiUrl}/{endpoint}", model);
        //    return response;
        //}

        public async Task PutAsync<T>(string url, T model)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            await client.PutAsJsonAsync($"{ApiUrl}/{url}", model);
        }

        public async Task PutAsync<T>(string url, int id, T model)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            await client.PutAsJsonAsync($"{ApiUrl}/{url}/{id}", model);
        }
        public async Task PutAsync<T>(string url, long id, T model)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            await client.PutAsJsonAsync($"{ApiUrl}/{url}/{id}", model);
        }

        public async Task DeleteAsync<T>(string url, int id)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync($"{ApiUrl}/{url}/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);

            if (responseObject != null)
            {
                await client.DeleteAsync($"{ApiUrl}/{url}/{id}");
            }
        }
        public async Task DeleteAsync<T>(string url, long id)
        {
            _token = HttpContext?.Request?.GetCookie(HaatBazaarConstants.CookieName) ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync($"{ApiUrl}/{url}/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);

            if (responseObject != null)
            {
                await client.DeleteAsync($"{ApiUrl}/{url}/{id}");
            }
        }
    }
}
