using Inventory.Application.Interface;
using Inventory.Domain.Entities;

namespace Inventory.Application.Services
{
    public class DiscountService
    {
        private readonly IDiscountRepository
            _repository;

        public DiscountService(
            IDiscountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Discount>>
            GetAllAsync()
        {
            return await _repository
                .GetAllAsync();
        }

        public async Task<Discount?>
            GetByIdAsync(int id)
        {
            return await _repository
                .GetByIdAsync(id);
        }

        public async Task SaveAsync(
            Discount model)
        {
            await _repository
                .SaveAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository
                .DeleteAsync(id);
        }
    }
}