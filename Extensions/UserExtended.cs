using System.Security.Claims;
using System.Security.Principal;

namespace DashmixMockups.Extensions
{
    public static class UserExtended
    {
        public static string GetFullName (this IPrincipal user) {
            var claim = ((ClaimsIdentity) user.Identity)?.FindFirst(ClaimTypes.Name);
            return claim?.Value;
        }
    }
}