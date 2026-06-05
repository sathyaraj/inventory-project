using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Persistence.Repositories
{
    public class ItemAssemblyRepository : IItemAssemblyRepository
    {
        private readonly AppDbContext _context;

        public ItemAssemblyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ItemAssembly> CreateAsync(ItemAssembly model)
        {
            try
            {
                // Save parent first
                _context.ItemAssemblies.Add(model);
                await _context.SaveChangesAsync();

                // Now set AssemblyId for children
                if(model.Details != null && model.Details.Any())
                {
                    foreach (var detail in model.Details)
                    {
                        detail.AssemblyId = model.Id; // ✅ FIX
                    }

                   // _context.ItemAssemblyDetails.AddRange(model.Details);
                    await _context.SaveChangesAsync();
                }

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
            //_context.ItemAssemblies.Add(entity);
            //await _context.SaveChangesAsync();
            //return entity;
        }

        public async Task<List<ItemAssembly>> GetAllAsync()
        {
            return await _context.ItemAssemblies
                .Include(x => x.Details)
                .ToListAsync();
        }

        public async Task<ItemAssembly?> GetByIdAsync(int Itemid)
        {
            Console.WriteLine($"Searching ID: {Itemid}");

            var result = await _context.ItemAssemblies
                .Include(x => x.Details)
                .FirstOrDefaultAsync(x => x.Itemid == Itemid);

            Console.WriteLine(result == null ? "NOT FOUND" : "FOUND");

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.ItemAssemblies.FindAsync(id);
            if (data != null)
            {
                _context.ItemAssemblies.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
