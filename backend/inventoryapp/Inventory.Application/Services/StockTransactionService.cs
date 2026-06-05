using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class StockTransactionService : IStockTransactionRepository
    {
        private readonly IStockTransactionRepository
            _repository;

        public StockTransactionService(
            IStockTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<StockTransaction>
            CreateAsync(StockTransaction model)
        {
            return await _repository
                .CreateAsync(model);
        }

        public async Task<List<StockTransaction>>
            GetAllAsync()
        {
            return await _repository
                .GetAllAsync();
        }

        public async Task<StockTransaction?>
            GetByIdAsync(int id)
        {
            return await _repository
                .GetByIdAsync(id);
        }

        public async Task<List<StockTransaction>>
            GetByItemIdAsync(int itemId)
        {
            return await _repository
                .GetByItemIdAsync(itemId);
        }

        public async Task<bool> UpdateAsync(
            StockTransaction model)
        {
            return await _repository
                .UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository
                .DeleteAsync(id);
        }
    }
}
