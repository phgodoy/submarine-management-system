using Microsoft.AspNetCore.Mvc;
using Sms.Domain.Accont;
using Microsoft.AspNetCore.Authorization;
using Sms.WebApi.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Sms.Infra.Data.Identity;

namespace Sms.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAuthenticate authenticate, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _authenticate = authenticate;
            _configuration = configuration;
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
            var token = GenerateToken(request.Email);

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
            if (!registrationResult)
            {
                return BadRequest(new { Message = "Error registering the user. Please try again later." });
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

        /// <summary>
        /// Generates a JWT token for the user.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="roles">User roles</param>
        /// <returns>Generated token</returns>
        private UserToken GenerateToken(string email)
        {
            var claims = new[]
            {
                new Claim("email", email),
                new Claim("meuvalor", "oque voce quiser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _configuration["Jwt:Issuer"],
                //audiencia
                audience: _configuration["Jwt:Audience"],
                //claims
                claims: claims,
                //data de expiracao
                expires: expiration,
                //assinatura digital
                signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
