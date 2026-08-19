namespace Sms.Infra.Ioc.Authentication;

public sealed record TokenResult(string Token, DateTime Expiration);
