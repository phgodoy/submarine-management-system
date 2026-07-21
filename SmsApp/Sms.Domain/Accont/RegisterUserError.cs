namespace Sms.Domain.Accont
{
    public class RegisterUserError
    {
        public RegisterUserError(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }

        public string Description { get; }
    }
}
