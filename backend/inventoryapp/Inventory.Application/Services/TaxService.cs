using Inventory.Application.Interface;
using Inventory.Domain.Entities;

namespace Inventory.Application.Services
{
    public class TaxService
    {
        private readonly ITaxRepository
            _repository;

        public TaxService(
            ITaxRepository repository)
        {
            _repository = repository;
        }

        // GET ALL
        public async Task<List<Tax>>
            GetAllAsync()
        {
            return await _repository
                .GetAllAsync();
        }

        // GET BY ID
        public async Task<Tax?>
            GetByIdAsync(int id)
        {
            return await _repository
                .GetByIdAsync(id);
        }

        // SAVE
        public async Task SaveAsync(
            Tax model)
        {
            // VALIDATION

            if (string.IsNullOrWhiteSpace(
                model.TaxName))
            {
                throw new Exception(
                    "Tax Name is required"
                );
            }

            if (string.IsNullOrWhiteSpace(
                model.TaxCode))
            {
                throw new Exception(
                    "Tax Code is required"
                );
            }

            await _repository
                .SaveAsync(model);
        }

        // DELETE
        public async Task DeleteAsync(
            int id)
        {
            await _repository
                .DeleteAsync(id);
        }
    }
}