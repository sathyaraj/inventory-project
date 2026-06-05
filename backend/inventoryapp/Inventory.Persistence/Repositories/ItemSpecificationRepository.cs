using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Inventory.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class ItemSpecificationRepository : IItemSpecificationRepository
    {
        private readonly AppDbContext _context;

        public ItemSpecificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ItemSpecification> CreateAsync(ItemSpecification model)
        {
            try
            {
                // 1. Save parent
                _context.ItemSpecification.Add(model);
                await _context.SaveChangesAsync();

                // 2. Save children
                if (model.Details != null && model.Details.Any())
                {
                    foreach (var detail in model.Details)
                    {
                        detail.ItemSpecificationId = model.Id;

                        //_context.ItemSpecificationDetails.Add(detail); // ✅ MUST be child DbSet
                    }

                    await _context.SaveChangesAsync();
                }

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<ItemSpecification>> GetAllAsync()
        {
            return await _context.ItemSpecification
                .Include(x => x.Details)
                .ToListAsync();
        }

        public async Task<ItemSpecification> GetByIdAsync(int itemId)
        {
            var data = await _context.ItemSpecification
                .Include(x => x.Details)
                .FirstOrDefaultAsync(x => x.Itemid == itemId);

            if (data == null)
                return null;

            var childIds = data.Details
                .Select(d => d.ItemSpecificationId)
                .ToList();

            // use childIds if needed

            return data;
        }


        public async Task DeleteAsync(int id)
        {
            var data = await _context.ItemSpecification.FindAsync(id);
            if (data != null)
            {
                _context.ItemSpecification.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}