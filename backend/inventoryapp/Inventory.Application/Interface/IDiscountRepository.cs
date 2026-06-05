using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IDiscountRepository
    {
        Task<List<Discount>> GetAllAsync();

        Task<Discount?> GetByIdAsync(int id);

        Task SaveAsync(Discount model);

        Task DeleteAsync(int id);
    }
}
