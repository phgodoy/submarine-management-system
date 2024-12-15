namespace Sms.WebApi.Dtos
{
    /// <summary>
    /// DTO for save user token.
    /// </summary>
    public class UserTokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiration {  get; set; }
    }
}
