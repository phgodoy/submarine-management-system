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
            var roles = await _userManager.GetRolesAsync(user);

            // Generate the JWT token with roles included
            var token = GenerateToken(request.Email, roles);

            // Return the token and expiration time
            return Ok(new UserTokenDTO
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1) // The same duration as defined in the GenerateToken method
            });
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
        private string GenerateToken(string email, IEnumerable<string> roles)
        {
            // Use the correct key from configuration
            var jwtKey = _configuration["Jwt:SecretKey"];  // Alterado aqui para usar Jwt:SecretKey
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT SecretKey is not configured.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64),
                new Claim("email", email) // Custom claim for email
            };

            // Add roles to claims
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
