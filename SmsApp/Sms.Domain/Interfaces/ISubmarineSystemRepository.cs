using Sms.Domain.Entities;

namespace Sms.Domain.Interfaces
{
   public interface ISubmarineSystemRepository
   {
        Task<IEnumerable<SubmarineSystem>> GetSubmarineSystems();

        Task<SubmarineSystem> GetSubmarineSystemsById(int? id);

        Task<SubmarineSystem> CreateSubmarineSystem(SubmarineSystem submarineSystem);

        Task<bool> UpdateSubmarineSystem(SubmarineSystem submarineSystem);

        Task<bool> DisableSubmarineSystem(int id);

        Task<bool> EnableSubmarineSystem(int id);
   }
}
