﻿using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;
using Sms.Domain.Enums;
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

        public async Task<bool> Update(Submarine submarine)
        {
            _context.Submarines.Update(submarine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DisableSubmarine(int id)
        {
            bool systemEnable = true;

            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            var submarine = await GetSubmarineById(id);

            if (submarine == null)
                throw new KeyNotFoundException($"No submarine found with ID {id}.");

            if (submarine.SubmarineStatusId == SubmarineStatusEnum.Deactivated)
                systemEnable = false;

            submarine.UpdateSubmarineStatus(SubmarineStatusEnum.Deactivated);

            _context.Submarines.Update(submarine);
            var changes = await _context.SaveChangesAsync();

            return systemEnable;
        }

        public async Task<bool> EnableSubmarine(int id)
        {
            bool systemEnable = true;

            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            var submarine = await GetSubmarineById(id);

            if (submarine == null)
                throw new KeyNotFoundException($"No submarine found with ID {id}.");

            if (submarine.SubmarineStatusId == SubmarineStatusEnum.InOperation)
                systemEnable = false;

            submarine.UpdateSubmarineStatus(SubmarineStatusEnum.InOperation);

            _context.Submarines.Update(submarine);
            var changes = await _context.SaveChangesAsync();

            return systemEnable;
        }
    }
}
