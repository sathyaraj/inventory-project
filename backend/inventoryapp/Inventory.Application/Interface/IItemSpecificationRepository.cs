using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IItemSpecificationRepository
    {
        Task<ItemSpecification> CreateAsync(ItemSpecification model);
        Task<List<ItemSpecification>> GetAllAsync();
        Task<ItemSpecification> GetByIdAsync(int id);
        Task DeleteAsync(int id);

    }
}
