using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class DocumentDetailsRepository : IDocumentDetailsRepository
    {
        private readonly AppDbContext _context;

        public DocumentDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<DocumentDetails> documents)
        {
            await _context.DocumentDetails.AddRangeAsync(documents);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DocumentDetails>> GetByItemIdAsync(int itemId)
        {
            return await _context.DocumentDetails
                .Where(x => x.ItemId == itemId)
                .ToListAsync();
        }

    }
}
