namespace Sms.Domain.Accont
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);

        Task<RegisterUserResult> RegisterUser(string email, string password);

        Task Logout();

    }
}
