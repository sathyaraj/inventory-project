using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IMasterRepository
    {
        Task AddAsync(Master master);
        Task<List<Master>> GetAllAsync();
    }
}
