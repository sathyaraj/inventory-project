using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IItemListRepository
    {
        Task AddAsync(ItemList itemlist);

        Task<List<ItemList>> GetByIdAsync(int Id);

        Task<List<ItemList>> GetAllItems();
    }
}
