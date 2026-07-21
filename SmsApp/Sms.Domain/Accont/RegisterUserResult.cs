namespace Sms.Domain.Accont
{
    public class RegisterUserResult
    {
        private RegisterUserResult(bool succeeded, IEnumerable<RegisterUserError> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToList().AsReadOnly();
        }

        public bool Succeeded { get; }

        public IReadOnlyCollection<RegisterUserError> Errors { get; }

        public static RegisterUserResult Success()
        {
            return new RegisterUserResult(true, []);
        }

        public static RegisterUserResult Failed(IEnumerable<RegisterUserError> errors)
        {
            return new RegisterUserResult(false, errors);
        }
    }
}
