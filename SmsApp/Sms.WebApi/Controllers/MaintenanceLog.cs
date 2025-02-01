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
    public class MaintenanceLogsController : ControllerBase
    {
        private readonly IMaintenanceLogService _maintenanceLogService;

        public MaintenanceLogsController(IMaintenanceLogService maintenanceLogService)
        {
            _maintenanceLogService = maintenanceLogService ?? throw new ArgumentNullException(nameof(maintenanceLogService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var maintenanceLogs = await _maintenanceLogService.GetMaintenanceLogs();

            if (maintenanceLogs == null || !maintenanceLogs.Any())
                return NotFound("No maintenance logs found.");

            return Ok(maintenanceLogs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var maintenanceLog = await _maintenanceLogService.GetMaintenanceLogById(id);

            if (maintenanceLog == null)
                return NotFound("Maintenance log not found.");

            return Ok(maintenanceLog);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] MaintenanceLogDTO maintenanceLog)
        {
            if (maintenanceLog == null)
                return BadRequest("Invalid maintenance log data.");

            var createdLog = await _maintenanceLogService.CreateMaintenanceLog(maintenanceLog);

            if (createdLog == null)
                return BadRequest("Failed to create maintenance log.");

            return CreatedAtAction(nameof(GetById), new { id = createdLog.Id }, createdLog);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] MaintenanceLogDTO maintenanceLog)
        {
            if (maintenanceLog == null)
                return BadRequest(new { Message = "Invalid maintenance log data." });

            if (id != maintenanceLog.Id)
                return BadRequest(new { Message = "ID in the URL does not match the payload." });

            var updatedLog = await _maintenanceLogService.UpdateMaintenanceLog(id, maintenanceLog);

            if (updatedLog == null)
                return NotFound(new { Message = $"Maintenance log with ID {id} not found." });

            return Ok(new { Message = "Maintenance log updated successfully.", Data = updatedLog, UpdatedAt = DateTime.UtcNow });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _maintenanceLogService.GetMaintenanceLogById(id);
            if (exists == null)
                return NotFound(new { Message = $"Maintenance log with ID {id} not found." });

            await _maintenanceLogService.DeleteMaintenanceLog(id);
            return NoContent();
        }
    }
}
