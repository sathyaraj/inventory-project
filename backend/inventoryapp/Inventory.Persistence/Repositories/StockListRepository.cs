using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class StockListRepository : IStockListRepository
    {
        private readonly AppDbContext _context;

        public StockListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stocklist>> GetAllAsync()
        {
            return await _context.Stocklists.ToListAsync();
        }

        public async Task<Stocklist> GetByIdAsync(int id)
        {
            return await _context.Stocklists.FindAsync(id);
        }

        public async Task AddAsync(Stocklist stock)
        {
            stock.createdtime = DateTime.Now;
            _context.Stocklists.Add(stock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stocklist stock)
        {
            _context.Stocklists.Update(stock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Stocklists.FindAsync(id);
            if (data != null)
            {
                _context.Stocklists.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
