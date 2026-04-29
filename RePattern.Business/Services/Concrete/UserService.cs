using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RePattern.Business.Dtos.Auth;
using RePattern.Business.Services.Interfaces;
using RePattern.Common.Exceptions.Custom;
using RePattern.Data.Identity;
using System.Security.Claims;

namespace RePattern.Business.Services.Concrete
{
    public class UserService(UserManager<ApplicationUser> userManager, IMapper mapper) : IUserService
    {
        public async Task<UserResponse> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken)
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userId))
                throw new UnauthorizedException("User is not authenticated.");

            var user = await userManager.Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId, cancellationToken);

            if (user is null)
                throw new NotFoundException("User was not found.");

            return mapper.Map<UserResponse>(user);
        }
    }
}
