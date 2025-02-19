using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;
using Sms.Domain.Interfaces;
using Sms.Infra.Data.Context;

namespace Sms.Infra.Data.Repositories
{
    public class SubmarineRepository : ISubmarineRepository
    {
        private readonly ApplicationDbContext _context;

        public SubmarineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Submarine> Create(Submarine submarine)
        {
            _context.Add(submarine);
            await _context.SaveChangesAsync();
            return submarine;
        }

        public async Task<Submarine> GetSubmarineById(int? id)
        {
            return await _context.Submarines
                .Include(s => s.SubmarineStatus)
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<IEnumerable<Submarine>> GetSubmarines()
        {
            return await _context.Submarines
                .Include(e => e.SubmarineStatus)
                .ToListAsync();
        }

        public async Task<bool> DisableSubmarine(int id)
        {
            throw new NotImplementedException();
            //if (id <= 0)
            //    throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            //var submarine = await GetSubmarineById(id);

            //if (submarine == null)
            //    throw new KeyNotFoundException($"No submarine system found with ID {id}.");

            //if (submarine.Status.ToString() == "Disable")
            //    return false;

            //submarine.UpdateOperationalStatus("Disable");

            //_context.SubmarineSystems.Update(submarine);
            //var changes = await _context.SaveChangesAsync();

            //return changes > 0;
        }

        public Task<bool> EnableSubmarine(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Submarine> Update(Submarine submarine)
        {
            throw new NotImplementedException();
        }
    }
}
