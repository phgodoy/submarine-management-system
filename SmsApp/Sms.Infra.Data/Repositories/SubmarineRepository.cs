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

        public async Task<Submarine> GetByIdAsync(int id)
        {
            return await _context.Submarines.FindAsync(id);
        }

        public async Task<IEnumerable<Submarine>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Submarine>> GetByStatusAsync(int status)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Submarine>> GetByModelAsync(string model)
        {
            throw new NotImplementedException();
        }

        public async Task<Submarine> UpdateAsync(Submarine submarine)
        {
            _context.Update(submarine);
            await _context.SaveChangesAsync();
            return submarine;
        }

        public async Task DeleteAsync(int id)
        {
            var submarine = await GetByIdAsync(id);

            if (submarine == null)
                throw new KeyNotFoundException($"No submarine found with ID {id}.");

            _context.Remove(submarine);
            await _context.SaveChangesAsync();
        }

        public Task AddAsync(Submarine submarine)
        {
            throw new NotImplementedException();
        }

        Task ISubmarineRepository.UpdateAsync(Submarine submarine)
        {
            throw new NotImplementedException();
        }
    }
}
