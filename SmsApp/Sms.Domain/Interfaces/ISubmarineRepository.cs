using Sms.Domain.Entities;

namespace Sms.Domain.Interfaces
{
    public interface ISubmarineRepository
    {
        Task<IEnumerable<Submarine>> GetAllAsync();
        Task<Submarine?> GetByIdAsync(int id);
        Task AddAsync(Submarine submarine);
        Task UpdateAsync(Submarine submarine);
        Task DeleteAsync(int id);
    }
}
