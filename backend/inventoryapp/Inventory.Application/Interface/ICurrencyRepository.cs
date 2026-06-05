using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface ICurrencyRepository
    {
        Task<List<CurrencyDetails>> GetAllAsync();

        Task<CurrencyDetails?> GetByIdAsync(int id);

        Task AddAsync(CurrencyDetails currency);

        Task UpdateAsync(CurrencyDetails currency);

        Task DeleteAsync(int id);
    }
}

