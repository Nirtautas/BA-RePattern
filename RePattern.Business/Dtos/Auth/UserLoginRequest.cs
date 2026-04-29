namespace RePattern.Business.Dtos.Auth
{
    public record UserLoginRequest(
        string UserName,
        string Password
    );
}
