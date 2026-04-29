using System.Security.Claims;

namespace RePattern.Business.Utils.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(List<Claim> claims);
    }
}
