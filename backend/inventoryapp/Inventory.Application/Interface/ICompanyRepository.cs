using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inventory.Domain.Entities;

namespace Inventory.Application.Interface
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllAsync();

        Task<Company> GetByIdAsync(int id);

        Task<Company> AddAsync(Company company);

        Task<Company> UpdateAsync(Company company);

        Task<bool> DeleteAsync(int id);
    }
}
