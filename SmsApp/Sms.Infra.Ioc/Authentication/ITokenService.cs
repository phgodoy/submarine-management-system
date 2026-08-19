namespace Sms.Infra.Ioc.Authentication;

public interface ITokenService
{
    TokenResult GenerateToken(string email);
}
