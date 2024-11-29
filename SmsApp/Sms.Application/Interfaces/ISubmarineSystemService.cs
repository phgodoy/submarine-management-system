using Sms.Application.DTOs;

namespace Sms.Application.Interfaces
{
    /// <summary>
    /// Service interface for managing submarine systems.
    /// </summary>
    public interface ISubmarineSystemService
    {
        /// <summary>
        /// Retrieves all submarine systems.
        /// </summary>
        /// <returns>A collection of submarine system DTOs.</returns>
        Task<IEnumerable<SubmarineSystemDTO>> GetSubmarineSystems();

        /// <summary>
        /// Retrieves a submarine system by its ID.
        /// </summary>
        /// <param name="id">The ID of the submarine system.</param>
        /// <returns>The submarine system DTO, or null if not found.</returns>
        Task<SubmarineSystemDTO> GetSubmarineSystemById(int id);

        /// <summary>
        /// Creates a new submarine system.
        /// </summary>
        /// <param name="submarineSystem">The submarine system DTO to create.</param>
        /// <returns>The ID of the created submarine system.</returns>
        Task<SubmarineSystemDTO> CreateSubmarineSystem(SubmarineSystemDTO submarineSystem);

        /// <summary>
        /// Update a existent submarine system.
        /// </summary>
        /// <param name="submarineSystem">The submarine system DTO to update.</param>
        /// <returns>new informations about the submarine system.</returns>
        Task<SubmarineSystemDTO> UpdateSubmarineSystem(int id, SubmarineSystemDTO submarineSystem);


        /// <summary>
        /// Disable a submarine system.
        /// </summary>
        /// <param name="id">The ID of the submarine system to disable.</param>
        /// <param name="submarineSystemStatus">The new status for the submarine system.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        Task<bool> DisableSubmarineSystem(int id);

        /// <summary>
        /// Enable a submarine system.
        /// </summary>
        /// <param name="id">The ID of the submarine system to enable.</param>
        /// <param name="submarineSystemStatus">The new status for the submarine system.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        Task<bool> EnableSubmarineSystem(int id);
    }
}
