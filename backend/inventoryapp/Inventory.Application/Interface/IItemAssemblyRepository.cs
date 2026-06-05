using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IItemAssemblyRepository
    {
        Task<ItemAssembly> CreateAsync(ItemAssembly model);
        Task<List<ItemAssembly>> GetAllAsync();
        Task<ItemAssembly> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
