using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RePattern.Business.Dtos.Auth;
using RePattern.Business.Services.Interfaces;

namespace RePattern.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] UserLoginRequest credentials, CancellationToken cancellationToken)
        {
            var response = await authService.LoginUserAsync(credentials, cancellationToken);

            Response.Cookies.Append("access_token", response.JwtToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddHours(1),
                Path = "/"
            });

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegisterRequest request, CancellationToken cancellationToken)
        {
            var response = await authService.RegisterUserAsync(request, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(CancellationToken cancellationToken)
        {
            Response.Cookies.Delete("access_token");
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest forgotPasswordRequest, CancellationToken cancellationToken)
        {
            await authService.ForgotPasswordAsync(forgotPasswordRequest, cancellationToken);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken)
        {
            await authService.ResetPasswordAsync(resetPasswordRequest, cancellationToken);
            return NoContent();
        }
    }
}
