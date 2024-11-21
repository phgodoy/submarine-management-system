using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sms.Application.Interfaces;

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
        /// <returns>Submarine system details</
    }
}