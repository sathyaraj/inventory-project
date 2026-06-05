using Inventory.Domain.Entities;

public interface IItemConditionRepository
{
    Task AddItemCondition(List<ItemCondition> condition);
    Task<List<ItemCondition>> GetByItemId(int itemId);
    Task DeleteByItemId(int itemId);
}