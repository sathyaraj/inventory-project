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
    public class ServiceItemRepository: IServiceItemRepository
    {
        private readonly AppDbContext _context;

        public ServiceItemRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceItem>> GetAllAsync()
        {
            return await _context.ServiceItems
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<ServiceItem?> GetByIdAsync(int id)
        {
            return await _context.ServiceItems
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ServiceItem> CreateAsync(
            ServiceItem item)
        {
            _context.ServiceItems.Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task UpdateAsync(ServiceItem item)
        {
            _context.ServiceItems.Update(item);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ServiceItem item)
        {
            _context.ServiceItems.Remove(item);

            await _context.SaveChangesAsync();
        }

        public async Task<ServiceItem?> UpdateAsync(int id, ServiceItem item)
        {
            var existing = await _context.ServiceItems
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
                return null;

            existing.ServiceCode = item.ServiceCode;
            existing.ServiceName = item.ServiceName;
            existing.ServiceSet = item.ServiceSet;
            existing.CommodityGroup = item.CommodityGroup;
            existing.CommodityCode = item.CommodityCode;
            existing.Description = item.Description;
            existing.ReceiptTolerance = item.ReceiptTolerance;
            existing.OrderUnit = item.OrderUnit;
            existing.IssueUnit = item.IssueUnit;
            existing.MinimumServiceCost = item.MinimumServiceCost;
            existing.MaximumServiceCost = item.MaximumServiceCost;
            existing.LeadTimeDays = item.LeadTimeDays;
            existing.Status = item.Status;
            existing.ActiveForPurchase = item.ActiveForPurchase;
            existing.ActiveForWorkOrder = item.ActiveForWorkOrder;
            existing.Prorate = item.Prorate;
            existing.InspectionRequired = item.InspectionRequired;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.ServiceItems
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return false;

            _context.ServiceItems.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetLastInsertedIdAsync()
        {
            return await _context.ServiceItems
                .OrderByDescending(x => x.Id)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
        }
    }
}
