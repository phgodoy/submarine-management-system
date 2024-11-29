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

        public async Task<bool> DisableSubmarineSystem(int id)
        {
            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            // Obtém o sistema de submarino pelo ID
            var submarineSystem = await GetSubmarineSystemById(id);

            if (submarineSystem == null)
                throw new KeyNotFoundException($"No submarine system found with ID {id}.");

            // Verifica se o sistema já está desativado
            if (submarineSystem.OperationalStatus == "Disable")
                return false;

            // Atualiza o status operacional
            submarineSystem.UpdateSubmarineSystem("Disable");

            // Atualiza no banco de dados
            _context.SubmarineSystems.Update(submarineSystem);
            var changes = await _context.SaveChangesAsync();

            return changes > 0;
        }

        public async Task<bool> EnableSubmarineSystem(int id)
        {
            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            var submarineSystem = await GetSubmarineSystemById(id);

            if (submarineSystem == null)
                throw new KeyNotFoundException($"No submarine system found with ID {id}.");

            if (submarineSystem.OperationalStatus == " Enable")
                return false; 

            submarineSystem.UpdateSubmarineSystem("Enable");

            _context.SubmarineSystems.Update(submarineSystem);
            var changes = await _context.SaveChangesAsync();

            return changes > 0;
        }



        public async Task<SubmarineSystem> Update(SubmarineSystem submarineSystem)
        {
            _context.Update(submarineSystem);
            await _context.SaveChangesAsync();
            return submarineSystem;
        }
    }
}
