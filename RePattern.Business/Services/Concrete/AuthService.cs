using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RePattern.Business.Dtos.Auth;
using RePattern.Business.Services.Interfaces;
using RePattern.Business.Utils.EmailService.Dtos;
using RePattern.Business.Utils.EmailService.Interfaces;
using RePattern.Business.Utils.Interfaces;
using RePattern.Common.Constants;
using RePattern.Common.Exceptions.Custom;
using RePattern.Data.Identity;
using System.Security.Claims;

namespace RePattern.Business.Services.Concrete
{
    public class AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenGenerator jwtTokenGenerator,
        IEmailService emailService,
        IConfiguration configuration,
        IMapper mapper
        ) : IAuthService
    {
        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest userCredentials, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(userCredentials.UserName) ?? throw new NotFoundException("User was not found.");

            var result = await signInManager.CheckPasswordSignInAsync(user, userCredentials.Password, false);

            if (!result.Succeeded)
                throw new UnauthorizedException("Invalid login credentials.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
            };

            var jwtToken = jwtTokenGenerator.GenerateToken(claims);
            return new UserLoginResponse(user.Id, userCredentials.UserName, jwtToken);
        }

        public async Task<UserResponse> RegisterUserAsync(UserRegisterRequest registerUser, CancellationToken cancellationToken)
        {
            bool emailAlreadyExists = await userManager.Users.AnyAsync(u => u.Email == registerUser.Email);

            if (emailAlreadyExists)
                throw new BadRequestException($"There is already an account registered to - {registerUser.Email}!");

            bool usernameAlreadyExists = await userManager.Users.AnyAsync(u => u.UserName == registerUser.UserName);

            if (usernameAlreadyExists)
                throw new BadRequestException($"Username \"{registerUser.UserName}\" is already taken!");

            if (registerUser.Password != registerUser.RepeatPassword)
                throw new BadRequestException($"The entered passwords do not match!");

            var user = mapper.Map<ApplicationUser>(registerUser);
            user.CreationDate = DateTime.UtcNow;
            var response = await userManager.CreateAsync(user, registerUser.Password);

            if (response.Errors.Any())
                throw new BadRequestException(string.Join("\n", response.Errors.Select(err => err.Description)));

            try
            {
                await emailService.SendEmailAsync(new SendEmailRequest
                {
                    RecipientName = user.UserName,
                    RecipientEmail = user.Email,
                    Subject = EmailMessages.TOPIC_WELCOME,
                    Body = EmailMessages.BODY_REGISTER_WELCOME
                }, cancellationToken);
            }
            catch { }

            return mapper.Map<UserResponse>(user);
        }

        public async Task ForgotPasswordAsync(ForgotPasswordRequest forgotPasswordRequest, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(forgotPasswordRequest.Email);

            if (user is not null)
            {
                var frontendBaseUrl = configuration["FrontEndBaseUrl"];
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var resetLink = $"{frontendBaseUrl}/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}";

                await emailService.SendEmailAsync(new SendEmailRequest
                {
                    RecipientName = user.UserName,
                    RecipientEmail = user.Email,
                    Subject = EmailMessages.TOPIC_PASSWORD_RESET,
                    Body = $"{EmailMessages.BODY_PASSWORD_RESET}<br/><a href=\"{resetLink}\">Click here to reset your password</a>"
                }, cancellationToken);
            }

            return;
        }

        public async Task ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(resetPasswordRequest.Email)
                ?? throw new BadRequestException("Invalid credentials for password recovery used.");

            var response = await userManager.ResetPasswordAsync(user, resetPasswordRequest.ResetCode, resetPasswordRequest.NewPassword);

            if (response.Errors.Any())
                throw new BadRequestException(string.Join("\n", response.Errors.Select(err => err.Description)));

            return;
        }
    }
}
