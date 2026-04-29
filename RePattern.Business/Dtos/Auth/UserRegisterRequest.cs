namespace RePattern.Business.Dtos.Auth
{
    public record UserRegisterRequest(
        string UserName,
        string Email,
        string Password,
        string RepeatPassword
    );
}
