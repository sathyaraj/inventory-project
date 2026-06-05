using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class ItemListRepository : IItemListRepository
    {
        private readonly AppDbContext _context;

        public ItemListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ItemList itemlist)
        {
            await _context.ItemList.AddAsync(itemlist);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ItemList>> GetAllItems()
        {
            return await _context.ItemList
                .Where(x => x.Status == true)
                .ToListAsync();
        }

        public async Task<List<ItemList>> GetByIdAsync(int id)
        {
            return await _context.ItemList
                .Where(x => x.Id == id && x.Status)
                .ToListAsync();
        }
    }
}