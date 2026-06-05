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
    public class AlternatesRepository : IAlternatesRepository
    {
        private readonly AppDbContext _context;

        public AlternatesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAlternates(List<AlternatesItem> alternates)
        {
            await _context.Alternates.AddRangeAsync(alternates);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AlternatesItem>> GetByItemId(int itemId)
        {
            return await _context.Alternates
                .Where(x => x.ItemId == itemId)
                .ToListAsync();
        }

        public async Task DeleteByItemId(int itemId)
        {
            var data = await _context.Alternates
                .Where(x => x.ItemId == itemId)
                .ToListAsync();

            _context.RemoveRange(data);
            await _context.SaveChangesAsync();
        }

    }
}
