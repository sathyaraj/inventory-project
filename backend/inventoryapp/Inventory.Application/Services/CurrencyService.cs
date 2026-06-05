using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class CurrencyService
    {
        private readonly ICurrencyRepository _repository;

        public CurrencyService(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CurrencyDetails>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CurrencyDetails?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(CurrencyDetails currency)
        {
            await _repository.AddAsync(currency);
        }

        public async Task UpdateAsync(CurrencyDetails currency)
        {
            await _repository.UpdateAsync(currency);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
