using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IStockListRepository
    {
        Task<List<Stocklist>> GetAllAsync();
        Task<Stocklist> GetByIdAsync(int id);
        Task AddAsync(Stocklist stock);
        Task UpdateAsync(Stocklist stock);
        Task DeleteAsync(int id);
    }
}
