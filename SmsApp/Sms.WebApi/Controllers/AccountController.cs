using Microsoft.AspNetCore.Mvc;
using Sms.Domain.Accont;
using Microsoft.AspNetCore.Authorization;
using Sms.WebApi.Dtos;
using Microsoft.AspNetCore.Identity;
using Sms.Infra.Data.Identity;
using Sms.Infra.Ioc.Authentication;

namespace Sms.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAuthenticate authenticate, ITokenService tokenService, UserManager<ApplicationUser> userManager)
        {
            _authenticate = authenticate;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        /// <summary>
        /// Logs in the user and returns an authentication token.
        /// </summary>
        /// <param name="request">Login credentials</param>
        /// <returns>Authentication token</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Validate the request
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            // Authenticate the user
            var authResult = await _authenticate.Authenticate(request.Email, request.Password);

            // If authentication fails
            if (!authResult)
            {
                return Unauthorized(new { Message = "Invalid email or password." });
            }

            // Retrieve user details
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return Unauthorized(new { Message = "User not found." });
            }

            // Get roles associated with the user
            //var roles = await _userManager.GetRolesAsync(user);

            // Generate the JWT token with roles included
            var token = _tokenService.GenerateToken(request.Email);

            // Return the token and expiration time
            return Ok(token);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="request">User information for registration</param>
        /// <returns>Registration status</returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // Validate the request
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            // Attempt to register the user
            var registrationResult = await _authenticate.RegisterUser(request.Email, request.Password);

            // If registration fails
            if (!registrationResult.Succeeded)
            {
                return BadRequest(new
                {
                    Message = "Não foi possível registrar o usuário.",
                    Errors = registrationResult.Errors.Select(error => new
                    {
                        Field = GetIdentityErrorField(error.Code),
                        error.Code,
                        Message = GetFriendlyIdentityErrorMessage(error.Code, error.Description)
                    })
                });
            }

            // Success response
            return Ok(new { Message = "User successfully registered." });
        }

        /// <summary>
        /// Logs out the user.
        /// </summary>
        /// <returns>Logout status</returns>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Ok(new { Message = "Logout successful." });
        }

        private static string GetIdentityErrorField(string code)
        {
            if (code.StartsWith("Password", StringComparison.OrdinalIgnoreCase))
            {
                return nameof(RegisterRequest.Password);
            }

            if (code.Contains("Email", StringComparison.OrdinalIgnoreCase) ||
                code.Contains("UserName", StringComparison.OrdinalIgnoreCase))
            {
                return nameof(RegisterRequest.Email);
            }

            return "User";
        }

        private static string GetFriendlyIdentityErrorMessage(string code, string fallbackMessage)
        {
            return code switch
            {
                "PasswordTooShort" => "A senha deve ter pelo menos 6 caracteres.",
                "PasswordRequiresUniqueChars" => "A senha deve conter caracteres diferentes entre si.",
                "PasswordRequiresNonAlphanumeric" => "A senha deve conter pelo menos um caractere especial, como !, @, # ou $.",
                "PasswordRequiresDigit" => "A senha deve conter pelo menos um número.",
                "PasswordRequiresLower" => "A senha deve conter pelo menos uma letra minúscula.",
                "PasswordRequiresUpper" => "A senha deve conter pelo menos uma letra maiúscula.",
                "DuplicateUserName" => "Já existe um usuário cadastrado com este e-mail.",
                "DuplicateEmail" => "Já existe um usuário cadastrado com este e-mail.",
                "InvalidEmail" => "Informe um e-mail válido.",
                _ => fallbackMessage
            };
        }
    }
}
