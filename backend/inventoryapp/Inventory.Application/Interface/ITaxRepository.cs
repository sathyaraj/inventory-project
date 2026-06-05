using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface ITaxRepository
    {
        Task<List<Tax>> GetAllAsync();

        Task<Tax?> GetByIdAsync(int id);

        Task SaveAsync(Tax model);

        Task DeleteAsync(int id);
    }
}
