using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IStoreroomItemRepository
    {
        Task AddItems(List<StoreroomItem> items);

        Task AddItemAsync(StoreroomItem item);

        Task<List<StoreroomItem>> GetAllAsync();

        Task<List<StoreroomItem>> GetByItemId(int itemId);
        Task DeleteByItemId(int itemId);

        //Task UpdateRangeAsync(List<StoreroomItem> StoreroomItem);


        Task<List<StoreroomItem>> GetByItemIdAsync(int itemId);

        Task<List<StoreroomItem>> GetByItemIdonlyAsync(int itemId);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateRangeAsync(List<StoreroomItem> StoreroomItem);


    }
}
