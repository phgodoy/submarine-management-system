using Sms.Application.Dtos;

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
        Task<IEnumerable<SubmarineSystemDto>> GetSubmarineSystems();

        /// <summary>
        /// Retrieves a submarine system by its ID.
        /// </summary>
        /// <param name="id">The ID of the submarine system.</param>
        /// <returns>The submarine system DTO, or null if not found.</returns>
        Task<SubmarineSystemDto> GetSubmarineSystemsById(int? id);

        /// <summary>
        /// Creates a new submarine system.
        /// </summary>
        /// <param name="submarineSystemDto">The submarine system DTO to create.</param>
        /// <returns>The created submarine system DTO, including the generated ID.</returns>
        Task<SubmarineSystemDto> CreateSubmarineSystem(SubmarineSystemDto submarineSystemDto);

        /// <summary>
        /// Updates an existing submarine system.
        /// </summary>
        /// <param name="submarineSystemDto">The updated submarine system DTO. The ID must be included in the DTO.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateSubmarineSystem(SubmarineSystemDto submarineSystemDto);

        /// <summary>
        /// Disables a submarine system (marks it as inactive).
        /// </summary>
        /// <param name="id">The ID of the submarine system to disable.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        Task<bool> DisableSubmarineSystem(int id);

        /// <summary>
        /// Enables a submarine system (marks it as active).
        /// </summary>
        /// <param name="id">The ID of the submarine system to enable.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        Task<bool> EnableSubmarineSystem(int id);
    }
}
