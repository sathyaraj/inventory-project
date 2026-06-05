using Inventory.Application.Interface;
using Inventory.Domain.Entities;

namespace Inventory.Application.Services
{
    public class ItemSpecificationService : IItemSpecificationRepository
    {
        private readonly IItemSpecificationRepository _repo;

        public ItemSpecificationService(IItemSpecificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<ItemSpecification> CreateAsync(ItemSpecification model)
        {
            // 👉 Business logic example
            if (model.Details == null || !model.Details.Any())
                throw new Exception("At least one assembly item is required");

            return await _repo.CreateAsync(model);
        }

        public async Task<List<ItemSpecification>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<ItemSpecification> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}