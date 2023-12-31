using Application.Common.Interfaces;
using System.Security.Claims;

namespace EFInterceptorPractice;

public class CurrentUser(IHttpContextAccessor _contextAccessor) : ICurrentUser
{
    public string? UserId => _contextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
