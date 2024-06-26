using HaatBazaar.Web.Models.Connections;
using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class ConnectionController(IConfiguration configuration) : BaseController(configuration)
    {
        private const string Endpoint = "connect";
        public async Task<IActionResult> Index(int connectionId)
        {
            var connection = await GetByIdAsync<ConnectionResponseModel>($"{Endpoint}", connectionId);
            return View(connection);
        }
    }
}
