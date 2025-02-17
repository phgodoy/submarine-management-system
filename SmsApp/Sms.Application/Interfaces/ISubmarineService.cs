using Sms.Application.Dtos;

namespace Sms.Application.Interfaces
{
    /// <summary>
    /// Service interface for managing submarines.
    /// </summary>
    public interface ISubmarineService
    {
        /// <summary>
        /// Retrieves all submarines.
        /// </summary>
        /// <returns>A collection of submarine DTOs.</returns>
        Task<IEnumerable<SubmarineDto>> GetSubmarines();

        /// <summary>
        /// Retrieves a submarine by its ID.
        /// </summary>
        /// <param name="id">The ID of the submarine.</param>
        /// <returns>The submarine DTO, or null if not found.</returns>
        Task<SubmarineDto> GetSubmarineById(int id);

        /// <summary>
        /// Creates a new submarine.
        /// </summary>
        /// <param name="submarineDto">The submarine DTO to create.</param>
        /// <returns>The ID of the created submarine.</returns>
        Task<SubmarineDto> CreateSubmarine(SubmarineDto submarineDto);

        /// <summary>
        /// Updates an existing submarine.
        /// </summary>
        /// <param name="id">The ID of the submarine to update.</param>
        /// <param name="submarineDto">The updated submarine DTO.</param>
        /// <returns>Updated submarine information.</returns>
        Task<SubmarineDto> UpdateSubmarine(int id, SubmarineDto submarineDto);

        /// <summary>
        /// Disables a submarine.
        /// </summary>
        /// <param name="id">The ID of the submarine to disable.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        Task<bool> DisableSubmarine(int id);

        /// <summary>
        /// Enables a submarine.
        /// </summary>
        /// <param name="id">The ID of the submarine to enable.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        Task<bool> EnableSubmarine(int id);
    }
}
