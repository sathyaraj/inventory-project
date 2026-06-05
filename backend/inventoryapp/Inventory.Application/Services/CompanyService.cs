using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Company> CreateAsync(Company company)
        {
            return await _repository.AddAsync(company);
        }

        public async Task<Company> UpdateAsync(Company company)
        {
            return await _repository.UpdateAsync(company);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Company> CreateCompanyAsync(
            Company company,
            IFormFile? logo
        )
        {

            string fileName = "";

            if (logo != null)
            {

                fileName = Guid.NewGuid().ToString() +
                           Path.GetExtension(
                               logo.FileName
                           );

                var folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/uploads/company-logo"
                );

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(
                        folderPath
                    );
                }

                var filePath = Path.Combine(
                    folderPath,
                    fileName
                );

                using (var stream =
                       new FileStream(
                           filePath,
                           FileMode.Create
                       ))
                {

                    await logo.CopyToAsync(stream);

                }

            }

            company.CompanyLogo = fileName;

            return await _repository.AddAsync(
                company
            );

        }

    }
}