using HaatBazaar.Web.Models.Blocks;
using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class TransactionController(IConfiguration configuration) : BaseController(configuration)
    {
        private string Endpoint = "transactions";
        public async Task<IActionResult> Index()
        {
            var transactions = await GetAllAsync<Block>(Endpoint);
            return View(transactions);
        }
    }
}
