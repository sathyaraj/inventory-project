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
        public class StockCancelRepository : IStockCancelRepository
        {
            private readonly AppDbContext _context;

            public StockCancelRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<StockCancel>> GetAll()
            {
                return await _context.StockCancels.ToListAsync();
            }

            public async Task<StockCancel?> GetById(int id)
            {
                return await _context.StockCancels
                    .FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<StockCancel> Create(StockCancel model)
            {
                _context.StockCancels.Add(model);

                await _context.SaveChangesAsync();

                return model;
            }

            public async Task<StockCancel?> Update(int id, StockCancel model)
            {
                var data = await _context.StockCancels.FindAsync(id);

                if (data == null)
                    return null;

                data.ItemId = model.ItemId;
                data.Qty = model.Qty;
                data.TransactionType = model.TransactionType;
                data.ReferenceNo = model.ReferenceNo;

                await _context.SaveChangesAsync();

                return data;
            }

            public async Task<bool> Delete(int id)
            {
                var data = await _context.StockCancels.FindAsync(id);

                if (data == null)
                    return false;

                _context.StockCancels.Remove(data);

                await _context.SaveChangesAsync();

                return true;
            }

            public async Task<bool> Cancel(int id)
            {
                var original = await _context.StockCancels
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (original == null || original.IsCancelled)
                    return false;

                original.IsCancelled = true;

                await _context.SaveChangesAsync();

                return true;
            }
        }
    }

