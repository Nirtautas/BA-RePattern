using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RePattern.Business.Utils.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RePattern.Business.Utils
{
    public class JwtTokenGenerator(IConfiguration configuration) : IJwtTokenGenerator
    {
        public string GenerateToken(List<Claim> claims)
        {
            var secretKey = configuration["RePatternJwtKey"];
            var issuer = configuration["RePatternIssuer"];
            var audience = configuration["RePatternAudience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken
            (
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
