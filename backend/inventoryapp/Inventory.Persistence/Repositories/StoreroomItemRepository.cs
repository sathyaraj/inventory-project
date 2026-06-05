using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Inventory.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Inventory.Persistence.Repositories.StoreroomRepository;

namespace Inventory.Persistence.Repositories
{
    public class StoreroomRepository : IStoreroomItemRepository
    {
        private readonly AppDbContext _context;

        public StoreroomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddItems(List<StoreroomItem> items)
        {
            await _context.StoreroomItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task AddItemAsync(StoreroomItem item)
        {
            await _context.StoreroomItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StoreroomItem>> GetByItemId(int itemId)
        {
            return await _context.StoreroomItems
                .Where(x => x.ItemId == itemId && x.IsActive == true && x.IsDelete != "D")
                .ToListAsync();
        }

        public async Task<List<StoreroomItem>> GetByItemIdonlyAsync(int itemId)
        {
            return await _context.StoreroomItems
                .Where(x => x.ItemId == itemId)
                .ToListAsync();
        }

        //public async Task UpdateRangeAsync(List<StoreroomItem> items)
        //{


        //    _context.StoreroomItems.UpdateRange(items);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<bool> UpdateRangeAsync(List<StoreroomItem> items)
        {
            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {

                foreach (var item in items)
                {
                    // TRANSFER QTY
                    var transferQty = item.CurrentBalance ?? 0;
                    var reduceQty = 0;

                    if (transferQty <= 0)
                    {
                        throw new Exception("Transfer quantity must be greater than zero");
                    }

                    // GET MAIN ITEM STOCK
                    var mainItem = await _context.Items
                        .FirstOrDefaultAsync(x => x.Id == item.ItemId);

                    if (mainItem == null)
                    {
                        throw new Exception("Main item not found");
                    }

                    Console.WriteLine($"Main Stock Before: {mainItem.Qty}");

                    // CHECK MAIN STOCK
                    if ((mainItem.Qty ?? 0) < transferQty)
                    {
                    }

                    // REDUCE MAIN STOCK
                    mainItem.Qty -= transferQty;

                    //reduceQty = mainItem.Qty;
                    // GET STOREROOM STOCK
                    var existing = await _context.StoreroomItems
                        .FirstOrDefaultAsync(x =>
                            x.Id == item.Id);

                    if (existing == null)
                    {
                        continue;
                    }


                    // ADD TO STOREROOM
                    existing.CurrentBalance =
                        (existing.CurrentBalance ?? 0) + transferQty;


                    // CREATE TRANSACTION
                    var stockTransaction = new StockTransaction
                    {
                        ItemId = item.ItemId,

                        QtyOut = transferQty,

                        QtyIn = mainItem.Qty ?? 0,

                        BalanceQty = mainItem.Qty ?? 0,

                        UnitCost = item.UnitCost ?? 0,

                        BalanceCost =
                            transferQty 
                            * (item.UnitCost ?? 0),

                        TransactionType = "ADD ITEM TO STOREROOM",

                        UserId = 1,

                        CreatedAt = DateTime.Now
                    };
             
                    await _context.StockTransactions
                        .AddAsync(stockTransaction);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                Console.WriteLine("STEP 9 - Transaction Committed");

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                Console.WriteLine("ERROR OCCURRED");
                Console.WriteLine(ex.Message);

                throw;
            }
        }

        public async Task<List<StoreroomItem>> GetByItemIdAsync(int itemId)
        {
            return await _context.StoreroomItems
                .Where(x => x.ItemId == itemId)
                .ToListAsync();
        }

        public async Task DeleteByItemId(int itemId)
        {
            var data = await _context.StoreroomItems
                .Where(x => x.ItemId == itemId)
                .ToListAsync();

            _context.StoreroomItems.RemoveRange(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StoreroomItem>> GetAllAsync()
        {
            return await _context.StoreroomItems
                .Where(x => x.IsActive)
                .ToListAsync();
        }


        public async Task<bool> DeleteAsync(int id)
        {

            var item = await _context.StoreroomItems
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return false;
            }

            item.IsDelete = "P";

            _context.StoreroomItems.Update(item);

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }



    }
}
