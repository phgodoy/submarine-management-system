using Sms.Domain.Entities;
using Sms.Infra.Data.Context;
using Sms.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Sms.Infra.Data.Repositories
{
    public class SubmarineSystemRepository : ISubmarineSystemRepository
    {
        private readonly ApplicationDbContext _context;

        public SubmarineSystemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SubmarineSystem> Create(SubmarineSystem submarineSystem)
        {
            _context.Add(submarineSystem);
            await _context.SaveChangesAsync();
            return submarineSystem;
        }

        public async Task<SubmarineSystem> GetSubmarineSystemById(int? id)
        {
            return await _context.SubmarineSystems.FindAsync(id);
        }

        public async Task<IEnumerable<SubmarineSystem>> GetSystems()
        {
            return await _context.SubmarineSystems.ToListAsync();
        }

        public async Task<SubmarineSystem> Remove(SubmarineSystem submarineSystem)
        {
            _context.Remove(submarineSystem);
            await _context.SaveChangesAsync();
            return submarineSystem;
        }

        public async Task<SubmarineSystem> Update(SubmarineSystem submarineSystem)
        {
            _context.Update(submarineSystem);
            await _context.SaveChangesAsync();
            return submarineSystem;
        }
    }
}
