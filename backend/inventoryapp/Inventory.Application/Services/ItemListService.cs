using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class ItemListService
    {
        private readonly IItemListRepository _repo;
         
        public ItemListService(IItemListRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(ItemList itemList)
        {
            await _repo.AddAsync(itemList);
        }

        public async Task<List<ItemList>> GetAllItems()
        {
            return await _repo.GetAllItems();
        }
    }
}
