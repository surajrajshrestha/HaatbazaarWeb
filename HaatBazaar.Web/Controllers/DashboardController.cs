using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
