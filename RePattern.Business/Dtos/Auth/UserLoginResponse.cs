namespace RePattern.Business.Dtos.Auth
{
    public record UserLoginResponse(
        int Id,
        string Username,
        string JwtToken
    );
}
