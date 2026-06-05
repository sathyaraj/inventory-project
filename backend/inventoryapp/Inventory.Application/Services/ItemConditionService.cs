using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Servies
{
    public class ItemConditionService
    {
        private readonly IItemConditionRepository _repo;
        public ItemConditionService(IItemConditionRepository repo) {
            _repo = repo;
        }

        public async Task<List<ItemCondition>> GetByItemId(int itemId)
        {
            return await _repo.GetByItemId(itemId);
        }

        public async Task AddItemCondition(int itemId, List<ItemCondition> conditions)
        {
            if (conditions == null || !conditions.Any())
                return;

            foreach (var cond in conditions)
            {
                cond.ItemId = itemId;
            }

            await _repo.AddItemCondition(conditions);
        }

        public async Task DeleteByItemId(int itemId)
        {
            await _repo.DeleteByItemId(itemId);
        }
    }
}
