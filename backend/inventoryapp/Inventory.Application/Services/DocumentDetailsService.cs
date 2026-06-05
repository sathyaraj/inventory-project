using Inventory.Application.Interface;
using Inventory.Domain.Entities;

namespace Inventory.Application.Services
{
    public class DocumentDetailsService
    {
        private readonly IDocumentDetailsRepository _repo;

        public DocumentDetailsService(IDocumentDetailsRepository repo)
        {
            _repo = repo;
        }

        public async Task SaveAsync(int itemId, List<DocumentDetails> documents)
        {
            foreach (var doc in documents)
            {
                doc.ItemId = itemId;
            }

            await _repo.AddRangeAsync(documents);
        }

        public async Task<List<DocumentDetails>> GetByItemIdAsync(int itemId)
        {
            return await _repo.GetByItemIdAsync(itemId);
        }
    }
}