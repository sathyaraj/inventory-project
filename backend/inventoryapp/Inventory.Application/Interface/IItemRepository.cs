using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interface
{
    public interface IItemRepository
    {

      Task AddAsync(Item item);
    Task<List<Item>> GetAllAsync();
    Task<Item?> GetByIdAsync(int id);
    //Task UpdateAsync(Item item);
    Task<int> GetLastInsertedIdAsync();
    Task<bool> DeleteAsync(int id);
    Task<Item> GetItemById(int id);

    Task<bool> UpdateAsync(Item item);

    Task AddItemsAsync(List<Item> items);

     Task AddRangeAsync(List<Item> items);
    Task<List<object>> GetGroupedItemsAsync();

     Task AddItemWithStockAsync(Item item);
        //List<Item> GetItemsWithStoreroom();
    }



}
