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
    public class MasterRepository : IMasterRepository
    {
        private readonly AppDbContext _context;

        public MasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Master master)
        {
            await _context.Masters.AddAsync(master);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Master>> GetAllAsync()
        {
            return await _context.Masters.ToListAsync();
        }
    }
}