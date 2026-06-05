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
    public class MasterdetailRepository : IMasterdetailRepository
    {
        private readonly AppDbContext _context;

        public MasterdetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Masterdetail masterdetail)
        {
            await _context.Masterdetails.AddAsync(masterdetail);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Masterdetail>> GetByMasterIdAsync(int masterId)
        {
            return await _context.Masterdetails
                .Where(x => x.MasterId == masterId && x.Status == true)
                .ToListAsync();
        }


    }
}
