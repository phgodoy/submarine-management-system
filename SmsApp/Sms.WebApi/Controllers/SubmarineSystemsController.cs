using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Application.SubmarineSystems.Queries;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;
using Sms.Infra.Data.Repositories;

namespace Sms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SubmarineSystemsController : ControllerBase
    {
        private readonly ISubmarineSystemRepository _submarineSystemRepository;

        public SubmarineSystemsController(ISubmarineSystemRepository submarineSystemRepository)
        {
            _submarineSystemRepository = submarineSystemRepository ?? throw new ArgumentNullException(nameof(submarineSystemRepository));
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
            var submarineSystems = await _submarineSystemRepository.GetSystems();

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