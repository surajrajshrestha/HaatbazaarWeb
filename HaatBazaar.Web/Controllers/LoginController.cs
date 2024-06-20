using HaatBazaar.Web.Helpers;
using HaatBazaar.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class LoginController(IConfiguration configuration) : BaseController(configuration)
    {
        private const string Endpoint = "auth";
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var response = await PostAsync($"{Endpoint}/register", register);
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await PostAsync($"{Endpoint}/login", login);
            var token = await response.Content.ReadAsStringAsync();

            Response.Cookies.Append(HaatBazaarConstants.CookieName, token, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(30)
            });
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
