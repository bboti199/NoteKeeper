using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NoteKeeper.Infrastructure.Interfaces;

namespace NoteKeeper.Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public string GetUserIdFromContext()
        {
            var userId =
                _httpContextAccessor.HttpContext.User.Claims.
                    FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return userId;
        }
    }
}