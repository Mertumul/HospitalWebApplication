using System.Security.Claims;

namespace HospitalWebApplication.Services
{
    // IUserAccessor arayüzü
    public interface IUserAccessor
    {
        string GetCurrentUserId();
    }

    // UserAccessor sınıfı
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
