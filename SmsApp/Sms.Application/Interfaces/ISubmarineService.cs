using Sms.Application.DTOs;

namespace Sms.Application.Interfaces
{
    public interface ISubmarineService
    {
        /// <summary>
        /// Creates a new submarine.
        /// </summary>
        /// <param name="submarineSystem">The submarine DTO to create.</param>
        /// <returns>The ID of the created submarine.</returns>
        Task<SubmarineDto> CreateSubmarine(SubmarineDto submarineDto);
    }
}
