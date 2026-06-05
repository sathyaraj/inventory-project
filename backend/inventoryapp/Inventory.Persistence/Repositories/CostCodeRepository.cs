using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Persistence.Repositories
{
   
    public class CostCodeRepository : ICostCodeRepository
    {
        private readonly AppDbContext _context;

        public CostCodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CostCode>> GetAllAsync()
        {
            return await _context.CostCodes.ToListAsync();
        }

        public async Task<CostCode?> GetByIdAsync(int id)
        {
            return await _context.CostCodes.FindAsync(id);
        }

        public async Task AddAsync(CostCode costCode)
        {
            _context.CostCodes.Add(costCode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CostCode costCode)
        {
            _context.CostCodes.Update(costCode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var costCode = await _context.CostCodes.FindAsync(id);

            if (costCode != null)
            {
                _context.CostCodes.Remove(costCode);
                await _context.SaveChangesAsync();
            }
        }
    }
}
