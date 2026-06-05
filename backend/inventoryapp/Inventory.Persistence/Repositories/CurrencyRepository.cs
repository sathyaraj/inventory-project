using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly AppDbContext _context;

        public CurrencyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CurrencyDetails>> GetAllAsync()
        {
            return await _context.CurrencyDetails.ToListAsync();
        }

        public async Task<CurrencyDetails?> GetByIdAsync(int id)
        {
            return await _context.CurrencyDetails
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(CurrencyDetails currency)
        {
            await _context.CurrencyDetails.AddAsync(currency);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CurrencyDetails currency)
        {
            _context.CurrencyDetails.Update(currency);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.CurrencyDetails
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                _context.CurrencyDetails.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}