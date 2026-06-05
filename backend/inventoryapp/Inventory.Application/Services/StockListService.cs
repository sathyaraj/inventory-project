using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class StockListService
    {
        private readonly IStockListRepository _repo;

        public StockListService(IStockListRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Stocklist>> GetAll()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Stocklist> GetById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task Add(Stocklist stock)
        {
            await _repo.AddAsync(stock);
        }

        public async Task Update(Stocklist stock)
        {
            await _repo.UpdateAsync(stock);
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
