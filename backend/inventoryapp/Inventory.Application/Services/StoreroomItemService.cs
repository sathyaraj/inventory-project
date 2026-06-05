using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Servies
{
    public class StoreroomService
    {
        private readonly IStoreroomItemRepository _repo;

        public StoreroomService(IStoreroomItemRepository repo)
        {
            _repo = repo;
        }

        // 🔍 LIST
        public async Task<List<StoreroomItem>> GetByItemId(int itemId)
        {
            return await _repo.GetByItemId(itemId);
        }

        // ➕ SAVE
        public async Task SaveItems(int itemId, List<StoreroomItem> items)
        {
            if (items == null || !items.Any())
                return;

            foreach (var item in items)
            {
                item.ItemId = itemId;
            }

            await _repo.AddItems(items);
        }

        public async Task AddItemAsync(StoreroomItem item)
        {
            if (item == null)
                throw new Exception("No item found");

            await _repo.AddItemAsync(item);
        }

        public async Task UpdateStatusAsync(int itemId, bool status)
        {
            var items = await _repo.GetByItemIdonlyAsync(itemId);

            if (items == null || !items.Any())
            {
                throw new Exception("No records found");
            }

            foreach (var item in items)
            {
                Console.WriteLine(status);
                Console.WriteLine(itemId);
                item.IsActive = status;

                if(item.IsDelete == "P")
                {
                    item.IsDelete = "D";
                }
            }

            await _repo.UpdateRangeAsync(items);
        }



        // ✏️ UPDATE (BEST PRACTICE)
        public async Task UpdateItems(int itemId, List<StoreroomItem> items)
        {
            // delete old
            await _repo.DeleteByItemId(itemId);

            // insert new
            await SaveItems(itemId, items);
        }

        public async Task<List<StoreroomItem>> GetAllItems()
        {
            return await _repo.GetAllAsync(); // already filtered in repo
        }

        public async Task<bool> DeleteItem(int id)
        {
            return await _repo.DeleteAsync(id); // clean
        }
    }
}
