using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
     public class AlternatesService
    {
        private readonly IAlternatesRepository _repo;

        public AlternatesService(IAlternatesRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<AlternatesItem>> GetByItemId(int itemId)
        {
            return await _repo.GetByItemId(itemId);
        }
        public async Task SaveAlternates(int itemId, List<AlternatesItem> alternates)
        {
            if (alternates == null || !alternates.Any())
                return;

            foreach (var alt in alternates)
            {
                alt.ItemId = itemId;
            }

            await _repo.AddAlternates(alternates);
        }

        public async Task DeleteByItemId(int itemId)
        {
            await _repo.DeleteByItemId(itemId);
        }
    }
}
