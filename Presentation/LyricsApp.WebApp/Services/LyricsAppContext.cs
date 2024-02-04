using LyricsApp.Auth.Services;

namespace LyricsApp.WebApp.Services
{
    public class LyricsAppContext : IAppContext
    {
        private readonly HttpContext _httpContext;


        public LyricsAppContext(IHttpContextAccessor httpContext)
        {
            if (httpContext == null || httpContext.HttpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            _httpContext = httpContext.HttpContext;
        }

        public Guid GetUserId()
        {
            return !string.IsNullOrEmpty(_httpContext.User.FindFirst("UserId")?.Value)
                    ? new Guid(_httpContext.User.FindFirst("UserId")?.Value!)
                    : Guid.Empty;
        }
    }

}