using Sms.Domain.Entities;

namespace Sms.Domain.Interfaces
{
    public interface ISubmarineSystem
    {
        Task<IEnumerable<SubmarineSystem>> GetSystems();

        Task<SubmarineSystem> GetById(int? id);

        Task<SubmarineSystem> Create(SubmarineSystem submarineSystem);

        Task<SubmarineSystem> Update(SubmarineSystem submarineSystem);

        Task<SubmarineSystem> Remove(SubmarineSystem submarineSystem);
    }
}
