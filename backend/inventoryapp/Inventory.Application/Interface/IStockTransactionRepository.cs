using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IStockTransactionRepository
    {
        Task<StockTransaction> CreateAsync(StockTransaction model);

        Task<List<StockTransaction>> GetAllAsync();

        Task<StockTransaction?> GetByIdAsync(int id);

        Task<List<StockTransaction>> GetByItemIdAsync(int itemId);

        Task<bool> UpdateAsync(StockTransaction model);

        Task<bool> DeleteAsync(int id);
    }
}
