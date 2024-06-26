using HaatBazaar.Web.Helpers;

namespace HaatBazaar.Web
{
    public class AuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public bool IsAuthenticated()
        {
            var token = _httpContextAccessor.HttpContext.Request.Cookies[HaatBazaarConstants.CookieName];
            return token != null;
        }

        public void Logout()
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies[HaatBazaarConstants.CookieName] != null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(HaatBazaarConstants.CookieName);
            }
        }
    }
}
