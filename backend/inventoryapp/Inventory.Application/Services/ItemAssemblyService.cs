using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Servies
{
    public class ItemAssemblyService : IItemAssemblyRepository
    {
        private readonly IItemAssemblyRepository _repo;


        public ItemAssemblyService(IItemAssemblyRepository repo)
        {
            _repo = repo;
        }

        public async Task<ItemAssembly> CreateAsync(ItemAssembly model)
        {
            // 👉 Business logic example
            if (model.Details == null || !model.Details.Any())
                throw new Exception("At least one assembly item is required");

            return await _repo.CreateAsync(model);
        }

        public async Task<List<ItemAssembly>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<ItemAssembly> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }

}
