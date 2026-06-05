using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Repositories
{
    public class DiscountRepository: IDiscountRepository
    {
        private readonly AppDbContext _context;

        public DiscountRepository(
            AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<Discount>>
            GetAllAsync()
        {
            return await _context.Discounts
                .ToListAsync();
        }

        // GET BY ID
        public async Task<Discount?>
            GetByIdAsync(int id)
        {
            return await _context.Discounts
                .FindAsync(id);
        }

        // SAVE
        public async Task SaveAsync(
            Discount model)
        {
            if (model.Id == 0)
            {
                await _context.Discounts
                    .AddAsync(model);
            }
            else
            {
                _context.Discounts
                    .Update(model);
            }

            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var data = await _context.Discounts
                .FindAsync(id);

            if (data != null)
            {
                _context.Discounts
                    .Remove(data);

                await _context.SaveChangesAsync();
            }
        }
    }
}