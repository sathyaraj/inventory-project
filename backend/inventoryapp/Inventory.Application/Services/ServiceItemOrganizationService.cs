using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class ServiceItemOrganizationService
    {
        private readonly IServiceItemOrganizationRepository _repo;

        public ServiceItemOrganizationService(IServiceItemOrganizationRepository repo)
        {
            _repo = repo;
        }

        public async Task<ServiceItemOrganization> CreateAsync(ServiceItemOrganization item)
        {
            return await _repo.AddAsync(item);
        }

        public async Task<List<ServiceItemOrganization>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
