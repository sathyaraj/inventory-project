using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company> AddAsync(Company company)
        {
            _context.Companies.Add(company);

            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<Company> UpdateAsync(Company company)
        {
            _context.Companies.Update(company);

            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await _context.Companies
                .FirstOrDefaultAsync(x => x.Id == id);

            if (company == null)
                return false;

            _context.Companies.Remove(company);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}