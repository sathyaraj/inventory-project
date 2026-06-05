using Inventory.Application.Interface;
using Inventory.Domain.Entities;

namespace Inventory.Application.Services
{
    public class ServiceItemService : IServiceItemRepository
    {
        private readonly IServiceItemRepository _repo;

        public ServiceItemService(IServiceItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<ServiceItem> CreateAsync(ServiceItem item)
        {
            if (string.IsNullOrWhiteSpace(item.ServiceCode))
                throw new Exception("Service Code is required");

            return await _repo.CreateAsync(item);
        }

        public async Task<List<ServiceItem>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<ServiceItem?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<ServiceItem?> UpdateAsync(int id, ServiceItem item)
        {
            return await _repo.UpdateAsync(id, item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<int> GetLastInsertedIdAsync()
        {
            return await _repo.GetLastInsertedIdAsync();
        }
    }
}