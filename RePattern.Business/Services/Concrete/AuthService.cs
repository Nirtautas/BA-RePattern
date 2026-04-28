using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RePattern.Business.Services.Interfaces;
using RePattern.Data.Identity;

namespace RePattern.Business.Services.Concrete
{
    public class AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mapper
        ) : IAuthService
    {
    }
}
