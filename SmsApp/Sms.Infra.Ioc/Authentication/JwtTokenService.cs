using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace Sms.Infra.Ioc.Authentication;

public sealed class JwtTokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResult GenerateToken(string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        var secretKey = GetRequiredSetting("Jwt:SecretKey");
        var issuer = GetRequiredSetting("Jwt:Issuer");
        var audience = GetRequiredSetting("Jwt:Audience");

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(10);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return new TokenResult(new JwtSecurityTokenHandler().WriteToken(token), expiration);
    }

    private string GetRequiredSetting(string key)
    {
        return _configuration[key]
            ?? throw new InvalidOperationException($"Configuration setting '{key}' was not found.");
    }
}
