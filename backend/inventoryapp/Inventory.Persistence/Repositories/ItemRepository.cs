using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item)
        {
            var alternates = item.Alternates;
            var conditions = item.Conditions;

            item.Alternates = null;
            item.Conditions = null;
            item.currentStock = item.currentStock + item.Qty;
            item.CreatedDate = DateTime.Now;

            // Optional
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            if (alternates != null && alternates.Any())
            {
                foreach (var alt in alternates)
                {
                    alt.ItemId = item.Id;
                }
                await _context.Set<AlternatesItem>().AddRangeAsync(alternates);
            }

            if (conditions != null && conditions.Any())
            {
                foreach (var cond in conditions)
                {
                    cond.ItemId = item.Id;
                }
                await _context.Set<ItemCondition>().AddRangeAsync(conditions);
            }


            await _context.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items
                .Where(x => x.Itemstatus == "A")
                .Include(x => x.Alternates)
                .Include(x => x.Conditions)
                .Include(x => x.StoreroomItems)
                .ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        //public async Task UpdateAsync(Item item)
        //{
        //    _context.Items.Update(item);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
                return false;

            item.Itemstatus = "D"; // soft delete
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<int> GetLastInsertedIdAsync()
        {
            return await _context.Items
                .OrderByDescending(x => x.Id)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
        }
       

        public async Task<bool> UpdateAsync(Item item)
        {

            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                var existing = await _context.Items
                    .FirstOrDefaultAsync(x => x.Id == item.Id);

                if (existing == null)
                {
                    return false;
                }

                var oldQty = existing.Qty ?? 0;
                var newQty = item.Qty ?? 0;

                var difference =  oldQty - newQty;

                // Update item
                _context.Entry(existing)
                    .CurrentValues
                    .SetValues(item);

                // Stock table
                var stock = await _context.Stocklists
                    .FirstOrDefaultAsync(x => x.ItemId == item.Id);

                if (stock != null)
                {
                    stock.qty = newQty;

                    // Transaction Entry
                    var stockTransaction = new StockTransaction
                    {
                        ItemId = item.Id,

                        //QtyOut = difference < 0 ? difference : 0,

                        QtyIn = newQty,

                        QtyOut = difference > 0
                            ? Math.Abs(difference)
                            : 0,


                        UnitCost = item.UnitCost ?? 0,

                        BalanceQty = newQty,

                        BalanceCost = newQty * (item.UnitCost ?? 0),

                        TransactionType =
                            difference >= 0 ? "IN" : "OUT",

                        UserId = 1,

                        CreatedAt = DateTime.Now
                    };

                    await _context.StockTransactions
                        .AddAsync(stockTransaction);

                }
                else
                {
                    Console.WriteLine("STEP 6A - Stock Not Found");
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                Console.WriteLine("ERROR OCCURRED");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);

                throw;
            }
        }

        
        public async Task AddItemsAsync(List<Item> items)
        {
            if (items == null || !items.Any())
                return;

            _context.Items.AddRange(items);
            await _context.SaveChangesAsync();

        }

        public async Task AddRangeAsync(List<Item> items)
        {
            _context.Items.AddRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task<List<dynamic>> GetGroupedItemsAsync()
        {
            var items = await _context.Items.ToListAsync();

            var data = items
                .GroupBy(x => x.ItemSet)
                .Select(g =>
                {
                    var latest = g.OrderByDescending(x => x.Id).First();

                    return (dynamic)new
                    {
                        ItemSet = g.Key,

                        Name = latest.Name,
                        ItemCode = latest.ItemCode,
                        CommodityGroup = latest.CommodityGroup,
                        CommodityCode = latest.CommodityCode,
                        LotType = latest.LotType,
                        Model = latest.Model,
                        SerialNo = latest.SerialNo,
                        Manufacturer = latest.Manufacturer,

                        MinimumStock = latest.MinimumStock,
                        MaximumStock = latest.MaximumStock,
                        ReorderLevel = latest.ReorderLevel,
                        SafetyStock = latest.SafetyStock,
                        ReorderQuantity = latest.ReorderQuantity,

                        CurrentStock = latest.currentStock,

                        OrderUnit = latest.OrderUnit,
                        IssueUnit = latest.IssueUnit,
                        Conversion = latest.Conversion,
                        LastPurchaseCost = latest.LastPurchaseCost,

                        LastId = latest.Id,
                        Total = g.Count()
                    };
                })
                .OrderByDescending(x => x.LastId)
                .ToList();

            return data;
        }

        public async Task AddItemWithStockAsync(Item item)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // STEP 1: Insert Item
                item.currentStock = item.Qty ?? 0;

                _context.Items.Add(item);
                await _context.SaveChangesAsync();

                // STEP 2: Update StockList (single row per item)
                var stock = await _context.Stocklists
                    .FirstOrDefaultAsync(x => x.ItemId == item.Id);

                if (stock == null)
                {
                    stock = new Stocklist
                    {
                        ItemId = item.Id,
                        ItemSet = item.ItemSet,
                        qty = item.Qty ?? 0,
                        status = true,
                        createdtime = DateTime.Now
                    };

                    _context.Stocklists.Add(stock);
                }
                else
                {
                    stock.qty += item.Qty ?? 0;
                }

                await _context.SaveChangesAsync();

                // STEP 3: Commit
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

    }
}