
using Sms.Domain.Entities;

namespace Sms.Domain.Interfaces
{
    public interface IMaintenanceLogRepository
    {
        Task<IEnumerable<MaintenanceLog>> GetAllAsync();
        Task<MaintenanceLog?> GetByIdAsync(int id);
        Task AddAsync(MaintenanceLog submarine);
        Task UpdateAsync(MaintenanceLog submarine);
        Task DeleteAsync(int id);
    }
}
