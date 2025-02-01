using Sms.Domain.Entities;
using Sms.Domain.Interfaces;
using Sms.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Sms.Infra.Data.Repositories
{
    public class MaintenanceLogRepository : IMaintenanceLogRepository
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceLog>> GetAllAsync()
        {
            return await _context.MaintenanceLogs.ToListAsync();
        }

        public async Task<MaintenanceLog?> GetByIdAsync(int id)
        {
            return await _context.MaintenanceLogs.FindAsync(id);
        }

        public async Task AddAsync(MaintenanceLog maintenanceLog)
        {
            await _context.MaintenanceLogs.AddAsync(maintenanceLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MaintenanceLog maintenanceLog)
        {
            _context.MaintenanceLogs.Update(maintenanceLog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var maintenanceLog = await GetByIdAsync(id);
            if (maintenanceLog == null)
                throw new KeyNotFoundException($"No maintenance log found with ID {id}.");

            _context.MaintenanceLogs.Remove(maintenanceLog);
            await _context.SaveChangesAsync();
        }
    }
}
