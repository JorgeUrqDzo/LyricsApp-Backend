using System.IdentityModel.Tokens.Jwt;

namespace LyricsApp.Auth.Services
{
    public interface IJwtTokenGeneratorService
    {
        string CreateSecurityToken(JwtSecurityToken jwt, string userId);
    }
}