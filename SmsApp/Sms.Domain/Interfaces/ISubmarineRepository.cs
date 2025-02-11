using Sms.Domain.Entities;

namespace Sms.Domain.Interfaces
{
    public interface ISubmarineRepository
    {
        Task<IEnumerable<Submarine>> GetSubmarines();

        Task<Submarine> GetSubmarineById(int? id);

        Task<Submarine> Create(Submarine submarine);

        Task<Submarine> Update(Submarine submarine);

        Task<bool> DisableSubmarine(int id);

        Task<bool> EnableSubmarine(int id);
    }
}
