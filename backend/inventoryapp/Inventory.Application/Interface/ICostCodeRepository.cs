using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface ICostCodeRepository
    {
        Task<List<CostCode>> GetAllAsync();

        Task<CostCode?> GetByIdAsync(int id);

        Task AddAsync(CostCode costCode);

        Task UpdateAsync(CostCode costCode);

        Task DeleteAsync(int id);
    }
}
