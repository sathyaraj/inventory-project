using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IDocumentDetailsRepository
    {
        Task AddRangeAsync(List<DocumentDetails> documents);
        Task<List<DocumentDetails>> GetByItemIdAsync(int itemId);
    }
}
