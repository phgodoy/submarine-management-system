using Microsoft.AspNetCore.Mvc;
using Sms.Application.DTOs;
using Sms.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Sms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubmarineController : ControllerBase
    {
        private readonly ISubmarineService _submarineService;

        public SubmarineController(ISubmarineService submarineService)
        {
            _submarineService = submarineService ?? throw new ArgumentNullException(nameof(submarineService));
        }

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

            return CreatedAtAction(
                nameof(CreateSubmarine),
                new { id = createdSubmarine.Id},
                createdSubmarine);
        }
    }
}
