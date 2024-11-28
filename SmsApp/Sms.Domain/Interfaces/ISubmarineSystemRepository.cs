using Sms.Domain.Entities;

namespace Sms.Domain.Interfaces
{
    public interface ISubmarineSystemRepository
    {
        Task<IEnumerable<SubmarineSystem>> GetSystems();

        Task<SubmarineSystem> GetSubmarineSystemById(int? id);

        Task<SubmarineSystem> Create(SubmarineSystem submarineSystem);

        Task<SubmarineSystem> Update(SubmarineSystem submarineSystem);

        Task<bool> DisableSubmarineSystem(int id);
    }
}
