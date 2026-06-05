using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IServiceItemRepository
    {
        Task<ServiceItem> CreateAsync(ServiceItem item);
        Task<List<ServiceItem>> GetAllAsync();
        Task<ServiceItem?> GetByIdAsync(int id);
        Task<ServiceItem?> UpdateAsync(int id, ServiceItem item);
        Task<bool> DeleteAsync(int id);

        Task<int> GetLastInsertedIdAsync();
    }
}
