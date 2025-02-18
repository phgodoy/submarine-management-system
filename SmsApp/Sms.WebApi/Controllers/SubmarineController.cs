using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sms.Application.Dtos;
using Sms.Application.Interfaces;

namespace Sms.WebApi.Controllers
{
    [ApiController]
    [Route("api/submarines")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubmarineController : ControllerBase
    {
        private readonly ISubmarineService _submarineService;

        public SubmarineController(ISubmarineService submarineService)
        {
            _submarineService = submarineService ?? throw new ArgumentNullException(nameof(submarineService));
        }

        /// <summary>
        /// Creates a new submarine.
        /// </summary>
        /// <param name="submarineDto">The submarine data.</param>
        /// <returns>Returns the created submarine.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubmarine([FromBody] SubmarineDto submarineDto)
        {
            if (submarineDto == null)
                return BadRequest("Invalid submarine data.");

            var createdSubmarine = await _submarineService.CreateSubmarine(submarineDto);

            if (createdSubmarine == null)
                return BadRequest("Failed to create submarine.");

            return Ok(createdSubmarine.Id);
        }

        /// <summary>
        /// Retrieves all registered submarines.
        /// </summary>
        /// <returns>A list of submarines.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SubmarineDto>>> GetSubmarines()
        {
            var submarines = await _submarineService.GetSubmarines();
            return Ok(submarines);
        }

        /// <summary>
        /// Retrieves a submarine by its ID.
        /// </summary>
        /// <param name="id">The submarine ID.</param>
        /// <returns>The submarine details.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubmarineById(int id)
        {
            var submarine = await _submarineService.GetSubmarineById(id);

            if (submarine == null)
                return NotFound($"Submarine with ID {id} not found.");

            return Ok(submarine);
        }
    }
}
