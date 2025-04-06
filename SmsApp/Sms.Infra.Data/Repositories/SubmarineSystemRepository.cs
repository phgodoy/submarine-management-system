using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;
using Sms.Domain.Enums;
using Sms.Domain.Interfaces;
using Sms.Infra.Data.Context;

namespace Sms.Infra.Data.Repositories
{
    public class SubmarineSystemRepository : ISubmarineSystemRepository
    {
        private readonly ApplicationDbContext _context;

        public async Task<SubmarineSystem> CreateSubmarineSystem(SubmarineSystem submarineSystem)
        {
            _context.Add(submarineSystem);
            await _context.SaveChangesAsync();
            return submarineSystem;
        }

        public async Task<bool> DisableSubmarineSystem(int id)
        {
            bool systemDisable = true;

            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            var submarineSystem = await GetSubmarineSystemsById(id);

            if (submarineSystem == null)
                throw new KeyNotFoundException($"No submarine system found with ID {id}.");

            if (submarineSystem.SystemStatus.ID == SystemStatusEnum.Disable)
                systemDisable = false;

            submarineSystem.UpdateOperationalSystem(SystemStatusEnum.Disable);

            _context.SubmarineSystem.Update(submarineSystem);
            var changes = await _context.SaveChangesAsync();

            return systemDisable;
        }

        public async Task<bool> EnableSubmarineSystem(int id)
        {
            bool systemEnable = true;

            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            var submarineSystem = await GetSubmarineSystemsById(id);

            if (submarineSystem == null)
                throw new KeyNotFoundException($"No submarine system found with ID {id}.");

            if (submarineSystem.SystemStatus.ID == SystemStatusEnum.InOperation)
                systemEnable = false;

            submarineSystem.UpdateOperationalSystem(SystemStatusEnum.InOperation);

            _context.SubmarineSystem.Update(submarineSystem);
            var changes = await _context.SaveChangesAsync();

            return systemEnable;
        }

        public async Task<IEnumerable<SubmarineSystem>> GetSubmarineSystems()
        {
            return await _context.SubmarineSystem
            .Include(e => e.SystemStatus)
            .ToListAsync();
        }

        public async Task<SubmarineSystem> GetSubmarineSystemsById(int? id)
        {
            return await _context.SubmarineSystem
                 .Include(s => s.SystemStatus)
                 .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<bool> UpdateSubmarineSystem(SubmarineSystem submarineSystem)
        {
            _context.SubmarineSystem.Update(submarineSystem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
