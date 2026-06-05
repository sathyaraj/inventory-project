// =============================
// TaxRepository.cs
// =============================

using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Repositories
{
    public class TaxRepository
        : ITaxRepository
    {
        private readonly AppDbContext _context;

        public TaxRepository(
            AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<Tax>>
            GetAllAsync()
        {
            return await _context.Taxes
                .ToListAsync();
        }

        // GET BY ID
        public async Task<Tax?>
            GetByIdAsync(int id)
        {
            return await _context.Taxes
                .FindAsync(id);
        }

        // SAVE
        public async Task SaveAsync(
            Tax model)
        {
            if (model.Id == 0)
            {
                // INSERT

                await _context.Taxes
                    .AddAsync(model);
            }
            else
            {
                // UPDATE

                var existingTax =
                    await _context.Taxes
                        .FindAsync(model.Id);

                if (existingTax == null)
                {
                    throw new Exception(
                        "Tax not found"
                    );
                }

                existingTax.TaxName =
                    model.TaxName;

                existingTax.TaxCode =
                    model.TaxCode;

                existingTax.TaxType =
                    model.TaxType;

                existingTax.TaxPercentage =
                    model.TaxPercentage;

                existingTax.EffectiveDate =
                    model.EffectiveDate;

                existingTax.Status =
                    model.Status;

                _context.Taxes
                    .Update(existingTax);
            }

            await _context
                .SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(
            int id)
        {
            var data =
                await _context.Taxes
                    .FindAsync(id);

            if (data == null)
            {
                throw new Exception(
                    "Tax not found"
                );
            }

            _context.Taxes
                .Remove(data);

            await _context
                .SaveChangesAsync();
        }
    }
}