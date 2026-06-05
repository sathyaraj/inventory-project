using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;

public class ItemConditionRepository : IItemConditionRepository
{
    private readonly AppDbContext _context;

    public ItemConditionRepository(AppDbContext context)
    {
        _context = context;
    }

    // ✅ EXACT MATCH (VERY IMPORTANT)
    public async Task AddItemCondition(List<ItemCondition> condition)
    {
        await _context.ItemConditions.AddRangeAsync(condition);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ItemCondition>> GetByItemId(int itemId)
    {
        return await _context.ItemConditions
            .Where(x => x.ItemId == itemId)
            .ToListAsync();
    }

    public async Task DeleteByItemId(int itemId)
    {
        var data = await _context.ItemConditions
            .Where(x => x.ItemId == itemId)
            .ToListAsync();

        _context.ItemConditions.RemoveRange(data);
        await _context.SaveChangesAsync();
    }
}