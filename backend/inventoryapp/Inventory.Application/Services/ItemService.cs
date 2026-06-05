using Inventory.Application.Interface;
using Inventory.Domain.Entities;

namespace Inventory.Application.Servies
{
    public class ItemService
    {
        private readonly IItemRepository _repo;

        public ItemService(IItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<Item> AddItem(Item item)
        {
            await _repo.AddAsync(item);
            return item;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _repo.GetAllAsync(); // already filtered in repo
        }

        public async Task<int> GetLastInsertedIdAsync()
        {
            return await _repo.GetLastInsertedIdAsync();
        }

        public async Task<bool> DeleteItem(int id)
        {
            return await _repo.DeleteAsync(id); // clean
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _repo.GetItemById(id);
        }

        public async Task<bool> UpdateItem(Item item)
        {
            return await _repo.UpdateAsync(item);
        }

        public async Task AddItemsAsync(List<Item> items)
        {
            await _repo.AddItemsAsync(items);
        }

        public async Task<List<object>> GetGroupedItemsAsync()
        {
            return await _repo.GetGroupedItemsAsync();
        }

        public async Task AddItemWithStockAsync(Item item)
        {
            await _repo.AddItemWithStockAsync(item);
        }

        //public List<Item> GetItems()
        //{
        //    return _repo.GetItemsWithStoreroom();
        //}
    }

}

    
    
