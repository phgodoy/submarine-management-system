using Sms.Application.DTOs;

namespace Sms.Application.Interfaces
{
    /// <summary>
    /// Service interface for managing maintenance logs.
    /// </summary>
    public interface IMaintenanceLogService
    {
        /// <summary>
        /// Retrieves all maintenance logs.
        /// </summary>
        /// <returns>A collection of maintenance log DTOs.</returns>
        Task<IEnumerable<MaintenanceLogDTO>> GetMaintenanceLogs();

        /// <summary>
        /// Retrieves a maintenance log by its ID.
        /// </summary>
        /// <param name="id">The ID of the maintenance log.</param>
        /// <returns>The maintenance log DTO, or null if not found.</returns>
        Task<MaintenanceLogDTO> GetMaintenanceLogById(int id);

        /// <summary>
        /// Creates a new maintenance log.
        /// </summary>
        /// <param name="maintenanceLog">The maintenance log DTO to create.</param>
        /// <returns>The created maintenance log DTO.</returns>
        Task<MaintenanceLogDTO> CreateMaintenanceLog(MaintenanceLogDTO maintenanceLog);

        /// <summary>
        /// Updates an existing maintenance log.
        /// </summary>
        /// <param name="id">The ID of the maintenance log to update.</param>
        /// <param name="maintenanceLog">The maintenance log DTO with updated information.</param>
        /// <returns>The updated maintenance log DTO.</returns>
        Task<MaintenanceLogDTO> UpdateMaintenanceLog(int id, MaintenanceLogDTO maintenanceLog);

        /// <summary>
        /// Deletes a maintenance log.
        /// </summary>
        /// <param name="id">The ID of the maintenance log to delete.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        Task<bool> DeleteMaintenanceLog(int id);
    }
}
