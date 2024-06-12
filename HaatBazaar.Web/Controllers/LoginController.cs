using HaatBazaar.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class LoginController(IConfiguration configuration) : BaseController(configuration, "auth")
    {
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            return View();
        }
    }
}
