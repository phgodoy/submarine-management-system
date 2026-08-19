namespace Sms.Infra.Ioc.Authentication;

public sealed class LocalTokenService : ITokenService
{
    public const string Token = "local-token";

    public TokenResult GenerateToken(string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        return new TokenResult(Token, DateTime.UtcNow.AddHours(1));
    }
}
