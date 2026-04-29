using RePattern.Business.Dtos.Auth;
using System.Security.Claims;

namespace RePattern.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken);
    }
}
