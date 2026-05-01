using Microsoft.AspNetCore.Identity.Data;
using RePattern.Business.Dtos.Auth;

namespace RePattern.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoginResponse> LoginUserAsync(UserLoginRequest userCredentials, CancellationToken cancellationToken);
        Task<UserResponse> RegisterUserAsync(UserRegisterRequest registerUser, CancellationToken cancellationToken);
        Task ForgotPasswordAsync(ForgotPasswordRequest forgotPasswordRequest, CancellationToken cancellationToken);
        Task ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken);
    }
}
