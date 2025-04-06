namespace Sms.Domain.Interfaces
{
    public interface ISubmarineRepository
    {
        Task<IEnumerable<Submarine>> GetSubmarines();

        Task<Submarine> GetSubmarineById(int? id);

        Task<Submarine> Create(Submarine submarine);

        Task<bool> Update(Submarine submarine);

        Task<bool> DisableSubmarine(int id);

        Task<bool> EnableSubmarine(int id);
    }
}
