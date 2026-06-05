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
    public class ServiceItemOrganizationRepository : IServiceItemOrganizationRepository
    {
        private readonly AppDbContext _context;

        public ServiceItemOrganizationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceItemOrganization> AddAsync(ServiceItemOrganization item)
        {
            _context.ServiceItemOrganizations.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<ServiceItemOrganization>> GetAllAsync()
        {

            return await _context.ServiceItemOrganizations.ToListAsync();            
            //return await _context.ServiceItems
            //    .Include(x => x.OrganizationDetails)
            //    .ToListAsync();
        }
    }
}
