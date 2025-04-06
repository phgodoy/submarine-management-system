using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sms.Application.Dtos;
using Sms.Application.Interfaces;

namespace Sms.WebApi.Controllers
{
    [ApiController]
    [Route("api/submarine-systems")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubmarineSystemController : ControllerBase
    {
        private readonly ISubmarineSystemService _submarineSystemService;

        public SubmarineSystemController(ISubmarineSystemService submarineSystemService)
        {
            _submarineSystemService = submarineSystemService ?? throw new ArgumentNullException(nameof(submarineSystemService));
        }

        /// <summary>
        /// Creates a new submarine system.
        /// </summary>
        /// <param name="submarineSystemDto">The submarine system data.</param>
        /// <returns>Returns the created system ID.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubmarineSystem([FromBody] SubmarineSystemDto submarineSystemDto)
        {
            if (submarineSystemDto == null)
                return BadRequest("Invalid submarine system data.");

            var createdSystem = await _submarineSystemService.CreateSubmarineSystem(submarineSystemDto);

            if (createdSystem == null)
                return BadRequest("Failed to create submarine system.");

            return Ok(createdSystem.Id);
        }

        /// <summary>
        /// Updates an existing submarine system.
        /// </summary>
        /// <param name="submarineSystemDto">Updated submarine system data.</param>
        /// <returns>Boolean indicating success.</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSubmarineSystem([FromBody] SubmarineSystemDto submarineSystemDto)
        {
            if (submarineSystemDto == null || submarineSystemDto.Id <= 0)
                return BadRequest("Invalid submarine system data.");

            var result = await _submarineSystemService.UpdateSubmarineSystem(submarineSystemDto);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves all submarine systems.
        /// </summary>
        /// <returns>A list of submarine systems.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SubmarineSystemDto>>> GetSubmarineSystems()
        {
            var systems = await _submarineSystemService.GetSubmarineSystems();
            return Ok(systems);
        }

        /// <summary>
        /// Retrieves a submarine system by ID.
        /// </summary>
        /// <param name="id">The system ID.</param>
        /// <returns>The system details.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubmarineSystemById(int id)
        {
            var system = await _submarineSystemService.GetSubmarineSystemsById(id);

            if (system == null)
                return NotFound($"Submarine system with ID {id} not found.");

            return Ok(system);
        }

        /// <summary>
        /// Disables a submarine system.
        /// </summary>
        /// <param name="id">The system ID.</param>
        /// <returns>Boolean indicating success.</returns>
        [HttpPut("{id:int}/disable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DisableSubmarineSystem(int id)
        {
            var result = await _submarineSystemService.DisableSubmarineSystem(id);
            return Ok(result);
        }

        /// <summary>
        /// Enables a submarine system.
        /// </summary>
        /// <param name="id">The system ID.</param>
        /// <returns>Boolean indicating success.</returns>
        [HttpPut("{id:int}/enable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EnableSubmarineSystem(int id)
        {
            var result = await _submarineSystemService.EnableSubmarineSystem(id);
            return Ok(result);
        }
    }
}
