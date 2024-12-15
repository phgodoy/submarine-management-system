using System.ComponentModel.DataAnnotations;

namespace Sms.WebApi.Dtos
{
    /// <summary>
    /// DTO for registration request.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// User's email address.
        /// </summary>
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        /// <summary>
        /// User's password.
        /// </summary>
        [Required(ErrorMessage = "The Password field is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed 50 characters.")]
        public string Password { get; set; }
    }
}
