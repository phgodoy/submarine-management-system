using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sms.Application.DTOs;
using Sms.Application.Interfaces;
using Sms.Domain.Entities;

namespace Sms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SubmarineSystemsController : ControllerBase
    {
        private readonly ISubmarineSystemService _submarineSystemService;

        public SubmarineSystemsController(ISubmarineSystemService submarineSystemService)
        {
            _submarineSystemService = submarineSystemService ?? throw new ArgumentNullException(nameof(submarineSystemService));
        }

        /// <summary>
        /// Get all submarine systems.
        /// </summary>
        /// <returns>List of submarine systems</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var submarineSystems = await _submarineSystemService.GetSubmarineSystems();

            if (submarineSystems == null || !submarineSystems.Any())
                return NotFound("No submarine systems found.");

            return Ok(submarineSystems);
        }

        /// <summary>
        /// Get a submarine system by ID.
        /// </summary>
        /// <param name="id">The ID of the submarine system</param>
        /// <returns>Submarine system details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var submarineSystem = await _submarineSystemService.GetSubmarineSystemById(id);

            if (submarineSystem == null)
                return NotFound("Submarine system not found.");

            return Ok(submarineSystem);
        }

        ///// <summary>
        ///// Create a new submarine system.
        ///// </summary>
        ///// <param name="submarineSystem">The submarine system data</param>
        ///// <returns>Created submarine system</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubmarineSystem([FromBody] SubmarineSystemDTO submarineSystem)
        {
            if (submarineSystem == null)
                return BadRequest("Invalid submarine system data.");

            var createdSubmarineSystem = await _submarineSystemService.CreateSubmarineSystem(submarineSystem);

            if (createdSubmarineSystem == null)
                return BadRequest("Failed to create submarine system.");

            return CreatedAtAction(
              nameof(GetById), // Assume you have a Get method to retrieve the resource
              new { id = createdSubmarineSystem.Id },
              createdSubmarineSystem);
        }

        /// <summary>
        /// Update an existing submarine system.
        /// </summary>
        /// <param name="id">The ID of the submarine system to update</param>
        /// <param name="submarineSystem">The updated submarine system data</param>
        /// <returns>Details of the updated submarine system</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSubmarineSystem(int id, [FromBody] SubmarineSystemDTO submarineSystem)
        {
            if (submarineSystem == null)
                return BadRequest(new { Message = "Invalid submarine system data." });

            // Check if the ID matches the payload
            if (id != submarineSystem.Id)
                return BadRequest(new { Message = "ID in the URL does not match the payload." });

            // Attempt to update the submarine system
            var updatedSubmarineSystem = await _submarineSystemService.UpdateSubmarineSystem(id, submarineSystem);

            if (updatedSubmarineSystem == null)
                return NotFound(new { Message = $"Submarine system with ID {id} not found." });

            var response = new
            {
                Message = "Submarine system updated successfully.",
                Data = updatedSubmarineSystem,
                UpdatedAt = DateTime.UtcNow
            };

            return Ok(response);
        }

        [HttpPut("{id}/disable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DisableSubmarineSystem(int id)
        {
            try
            {
                var result = await _submarineSystemService.DisableSubmarineSystem(id);

                if (!result)
                    return NotFound(new { Message = $"Submarine system with ID {id} not found or update failed." });

                return Ok(new { Message = "Submarine system status updated successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }
    }
}