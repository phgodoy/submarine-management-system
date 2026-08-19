namespace Sms.Infra.Ioc.Authentication;

public sealed class LocalTokenService(string token) : ITokenService
{
    public TokenResult GenerateToken(string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        return new TokenResult(token, DateTime.UtcNow.AddHours(1));
    }
}
