using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using LyricsApp.Auth.Services;
using LyricsApp.Auth.Settings;

using Microsoft.IdentityModel.Tokens;

namespace LyricsApp.JwtTokenHandler;

public class JwtTokenGenerator: IJwtTokenGeneratorService
{
    private readonly string _audience;
    private readonly string _issuer;
    private readonly string _signInKey = string.Empty;

    public JwtTokenGenerator(AuthenticationSettings authenticationSettings)
    {
        if (string.IsNullOrEmpty(authenticationSettings.Audience))
        {
            throw new ArgumentException($"'{nameof(authenticationSettings.Audience)}' cannot be null or empty.", nameof(authenticationSettings.Audience));
        }

        if (string.IsNullOrEmpty(authenticationSettings.Issuer))
        {
            throw new ArgumentException($"'{nameof(authenticationSettings.Issuer)}' cannot be null or empty.", nameof(authenticationSettings.Issuer));
        }

        if (string.IsNullOrEmpty(authenticationSettings.IssuerSigningKey))
        {
            throw new ArgumentException($"'{nameof(authenticationSettings.IssuerSigningKey)}' cannot be null or empty.", nameof(authenticationSettings.IssuerSigningKey));
        }

        _audience = authenticationSettings.Audience;
        _issuer = authenticationSettings.Issuer;
        _signInKey = authenticationSettings.IssuerSigningKey;
    }

    public string CreateSecurityToken(JwtSecurityToken jwt, string userId)
    {
        // var userId = jwt.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        var email = jwt.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
        var displayName = jwt.Claims.FirstOrDefault(c => c.Type == "DisplayName")?.Value;
        // var role = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        var expirationTime = 1440;

        var token = new JwtTokenBuilder()
                    .AddSecurityKey(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_signInKey)))
                    .AddSubject(jwt.Subject)
                    .AddIssuer(_issuer)
                    .AddAudience(_audience)
                    .AddClaim("UserId", userId)
                    .AddClaim("DisplayName", displayName ?? string.Empty)
                    .AddClaim("Email", email ?? string.Empty)
                    // .AddClaim(ClaimTypes.Role, role)
                    .AddExpiry(expirationTime)
                    .Build();

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
