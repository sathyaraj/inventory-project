using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IAlternatesRepository
    {
        Task AddAlternates(List<AlternatesItem> alternates);
        Task<List<AlternatesItem>> GetByItemId(int itemId);
        Task DeleteByItemId(int itemId);
    }
}
