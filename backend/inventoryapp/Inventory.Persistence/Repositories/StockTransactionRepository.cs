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

        public class StockTransactionRepository
       : IStockTransactionRepository
        {
            private readonly AppDbContext _context;

            public StockTransactionRepository(
                AppDbContext context)
            {
                _context = context;
            }

            public async Task<StockTransaction> CreateAsync(
                StockTransaction model)
            {
                await _context.StockTransactions
                    .AddAsync(model);

                await _context.SaveChangesAsync();

                return model;
            }

            public async Task<List<StockTransaction>>
                GetAllAsync()
            {
                return await _context.StockTransactions
                    .OrderByDescending(x => x.CreatedAt)
                    .ToListAsync();
            }

            public async Task<StockTransaction?>
                GetByIdAsync(int id)
            {
                return await _context.StockTransactions
                    .FirstOrDefaultAsync(x => x.StockTnsId == id);
            }

            public async Task<List<StockTransaction>>
                GetByItemIdAsync(int itemId)
            {
                return await _context.StockTransactions
                    .Where(x => x.ItemId == itemId)
                    .OrderByDescending(x => x.CreatedAt)
                    .ToListAsync();
            }

            public async Task<bool> UpdateAsync(
                StockTransaction model)
            {
                var existing = await _context.StockTransactions
                    .FirstOrDefaultAsync(
                        x => x.StockTnsId == model.StockTnsId);

                if (existing == null)
                {
                    return false;
                }

                _context.Entry(existing)
                    .CurrentValues
                    .SetValues(model);

                await _context.SaveChangesAsync();

                return true;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var existing = await _context.StockTransactions
                    .FirstOrDefaultAsync(x => x.StockTnsId == id);

                if (existing == null)
                {
                    return false;
                }

                _context.StockTransactions.Remove(existing);

                await _context.SaveChangesAsync();

                return true;
            }
        }
}
