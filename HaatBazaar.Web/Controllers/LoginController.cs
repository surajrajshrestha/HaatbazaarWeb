using System.Net;
using HaatBazaar.Web.Helpers;
using HaatBazaar.Web.Models;
using HaatBazaar.Web.Models.ResponseModels;
using HaatBazaar.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var responseString = await response.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<UserCreatedResponseModel>(responseString)!;

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                if (responseModel.NewUserCreated && !string.IsNullOrWhiteSpace(responseModel.Otp))
                {
                    var otpModel = new VerifyOtpModel { PhoneNumber = register.PhoneNumber };
                    return View("VerifyOtp", otpModel);
                }
            }

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

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseModel = JsonConvert.DeserializeObject<UserCreatedResponseModel>(responseString)!;

                if (responseModel.NewUserCreated && !string.IsNullOrWhiteSpace(responseModel.Otp))
                {
                    var otpModel = new VerifyOtpModel { PhoneNumber = login.PhoneNumber };
                    return View("VerifyOtp", otpModel);
                }
            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var token = await response.Content.ReadAsStringAsync();
                Response.Cookies.Append(HaatBazaarConstants.CookieName, token, new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddMinutes(30)
                });
                return RedirectToAction("Index", "UserItemsUi");
            }

            return View(login);
        }

        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var response = await PostAsync($"{Endpoint}/verify-otp", model);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var token = await response.Content.ReadAsStringAsync();
                Response.Cookies.Append(HaatBazaarConstants.CookieName, token, new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddMinutes(30)
                });
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }

    }
}
