namespace HaatBazaar.Web.Helpers
{
    public static class HttpRequestExtensions
    {
        public static string GetCookie(this HttpRequest request, string cookieName)
        {

            if (string.IsNullOrEmpty(cookieName))
                return "";

            return request.Cookies[cookieName] ?? "";
        }
    }
}
