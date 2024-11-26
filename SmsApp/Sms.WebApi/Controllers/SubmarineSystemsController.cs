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
    }
}