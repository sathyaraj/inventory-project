using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class CostCodeService
    {
        private readonly ICostCodeRepository _repository;

        public CostCodeService(ICostCodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CostCode>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CostCode?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(CostCode costCode)
        {
            await _repository.AddAsync(costCode);
        }

        public async Task UpdateAsync(CostCode costCode)
        {
            await _repository.UpdateAsync(costCode);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
